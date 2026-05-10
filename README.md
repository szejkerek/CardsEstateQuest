# CardsEstateQuest

[![Made With Unity](https://img.shields.io/badge/made%20with-Unity-57b9d3.svg?logo=Unity)](https://unity.com/)
[![Last Commit](https://img.shields.io/github/last-commit/szejkerek/CardsEstateQuest?logo=Mapbox&color=orange)](https://github.com/szejkerek/CardsEstateQuest/commits/main/)
[![Repo Size](https://img.shields.io/github/repo-size/szejkerek/CardsEstateQuest?logo=VirtualBox)]()
[![GitHub Release](https://img.shields.io/github/v/release/szejkerek/CardsEstateQuest)](https://github.com/szejkerek/CardsEstateQuest/releases)
[![GitHub stars](https://img.shields.io/github/stars/szejkerek/CardsEstateQuest?branch=main&label=Stars&logo=GitHub&logoColor=ffffff&labelColor=282828&color=informational&style=flat)](https://github.com/szejkerek)
[![GitHub user stars](https://img.shields.io/github/stars/szejkerek?affiliations=OWNER&branch=main&label=User%20Stars&logo=GitHub&logoColor=ffffff&labelColor=282828&color=informational&style=flat)](https://github.com/szejkerek)

## Overview

Computer game based on card game developed by the [URBANMODEL](http://urbanmodel.org/pl/grupa-badawcza/) at the Faculty of Architecture, Silesian University of Technology. The game, titled ["Gra w Osiedle"](https://www.grawosiedle.polsl.pl/), involves strategic competition between two players to accumulate more points using cards.

## Gameplay 
- Consists of 3 rounds; a player wins by achieving victory in 2 rounds.
- Board comprises squares with limited size.
- Cards, with dimensions 3x2, 2x2, or 2x1, have varying parameters.
- Players take turns placing one card per turn.
- First round: Players receive X cards and choose roles (*developer* or *ecologist*).
- Rounds end when both players pass; points are scored based on a point system.
- Winner determined by the player with the higher total points

## Roles
- **Developer**: Aims for high development intensity.
- **Ecologist**: Aims for a large biologically active area.

## Visual

![Screenshot_2](https://github.com/szejkerek/CardsEstateQuest/assets/69083596/d8f9bac0-c357-46af-a260-c332230f69fd)

![Screenshot_3](https://github.com/szejkerek/CardsEstateQuest/assets/69083596/bc896bdf-2788-492b-8840-2e9745ed8b94)

![Screenshot_7](https://github.com/szejkerek/CardsEstateQuest/assets/69083596/5231ca4b-9bfd-4bc5-a4f8-3f00b0f31d28)

![Screenshot_4](https://github.com/szejkerek/CardsEstateQuest/assets/69083596/3f065ba2-b200-467e-8899-46af7a8914ed)

## Downloading the Game

To get started and play the game, you can follow these simple steps to download the latest release from GitHub.

- Visit the [Releases](https://github.com/szejkerek/CardsEstateQuest/releases) page of our GitHub repository.
- Look for the latest release.
- Download the appropriate asset for your operating system.
- Follow the installation instructions for your specific operating system. After installation, you should be able to launch the game and start playing!

## Code Highlights

### Neighbor-Aware Card Placement Scoring

```csharp
private void CalculateAverageParameters()
{
    Vector3 currentPosition = transform.position;
    float x = GameplayManager.Instance.GridManager.gridSpacing.x;
    float y = GameplayManager.Instance.GridManager.gridSpacing.y;
    Vector3[] neighborPositions = {
        currentPosition + new Vector3(x , 0, 0),
        currentPosition + new Vector3(-x, 0, 0),
        currentPosition + new Vector3(0, 0, y),
        currentPosition + new Vector3(0, 0, -y)
    };
    
    float building = cardObject.Parameters[1].Value;
    float green = cardObject.Parameters[0].Value;

    foreach (Vector3 neighborPosition in neighborPositions)
    {
        GridItem neighbor = GameplayManager.Instance.GridManager.GetGridItemAtPosition(neighborPosition);

        if (neighbor != null)
        {
            if (neighbor.cardObject != null)
            {
                building += neighbor.cardObject.Parameters[1].Value;
                green += neighbor.cardObject.Parameters[0].Value;
                neighborCount++;
            }
        }
    }
    float avgBuilding = building / (neighborCount+1); 
    float avgGreen = green / (neighborCount+1);
    GameplayManager.Instance.RoundManager.AddPoint(Mathf.FloorToInt(avgGreen),Mathf.FloorToInt(avgBuilding));
}
```

`Assets/__Scripts/Grid/GridItem.cs:114-147`

The core scoring mechanic translates the physical board game's adjacency rules into 3D world-space neighbor lookup. Rather than maintaining an explicit grid data structure, it queries neighbors by computing world-space offsets from the grid's actual spacing values, then averages the green and building parameters across all occupied adjacent cells. The division by `neighborCount+1` (not `neighborCount`) correctly includes the placed card itself, creating an emergent clustering incentive where adjacent placements smooth outlier values and tend to raise the dominant parameter average.

### Quadrant-Aware Tooltip Positioning

```csharp
Vector2 velocity = Vector2.zero;
private void Update()
{
    Vector2 position = Input.mousePosition;
    Vector2 pivot = Vector2.zero;

    float screenWidth = Screen.width;
    float screenHeight = Screen.height;
    float threshold = 0.1f;

    if (position.x < screenWidth * 0.5f)
    {
        pivot.x = 0f;
    }
    else
    {
        pivot.x = 1f;
    }

    if (position.y < screenHeight * 0.5f)
    {
        pivot.y = 0f;
    }
    else
    {
        pivot.y = 1f;
    }

    rectTransform.pivot = pivot + new Vector2(pivot.x * threshold, pivot.y * threshold);
    Vector2 targetPosition = position;
    transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
}
```

`Assets/__Scripts/UI/Tooltip/Tooltip.cs:56-87`

Rather than clamping a fixed-pivot tooltip to screen bounds after the fact, this dynamically adjusts the RectTransform pivot based on which screen quadrant the cursor occupies. When the cursor is in the right half, the pivot flips to 1.0 so the tooltip grows leftward; the same logic applies vertically. A small threshold offset keeps the tooltip clear of the cursor hotspot. Combined with `SmoothDamp`, the tooltip never clips off-screen and follows the cursor with a slight lag.

### Incremental Moving Average for Parameter Tracking

```csharp
private float MovingAvarage(float newValue)
{
    if(cardsContributedToValue == 0)
    {
        return 0;
    }

    return value + ((newValue - value) / cardsContributedToValue);
}
```

`Assets/__Scripts/Card/Parameters/ParameterGoal.cs:107-115`

Implements the online incremental mean formula (`mean_n = mean_{n-1} + (x_n - mean_{n-1}) / n`) to track percentage-type parameters (such as biologically active area ratio) as cards are placed without accumulating a growing list of previous values. The caller also passes a negated delta when a card is removed (`cardDestroyed`), so the live average stays correct throughout the round without any full recomputation.
