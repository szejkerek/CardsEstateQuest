using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Transform buttonContainer; 
    public GameObject buttonPrefab; 


    CrudList<IDifficulty> difficulties = new CrudList<IDifficulty>();

    private void Start()
    {
        difficulties.LoadList(new DefaultLoader<IDifficulty>(), "GameData/Difficulty");
        GenerateLevelButtons();
    }

    void GenerateLevelButtons()
    {
        for (int i = 0; i < difficulties.Count; i++)
        {
            GameObject button = Instantiate(buttonPrefab, buttonContainer);
            button.GetComponentInChildren<TMP_Text>().text = difficulties.GetItem(i).Name;

            Transform childTransform = button.transform.Find("Image");
            Image childImage = childTransform.GetComponent<Image>();
            childImage.sprite = difficulties.GetItem(i).Icon; 
        }
    }
}
