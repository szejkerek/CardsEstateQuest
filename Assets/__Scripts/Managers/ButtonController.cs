using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Transform buttonContainer;
    public GameObject buttonPrefab;

    public void GenerateLevelButtons(CrudList<IDifficulty> difficulties)
    {
        for (int i = 0; i < difficulties.Count; i++)
        {
            GameObject button = Instantiate(buttonPrefab, buttonContainer);
            Transform childTransform = button.transform.Find("Image");
            Image childImage = childTransform.GetComponent<Image>();

            childImage.sprite = difficulties.GetItem(i).Icon;
            button.GetComponentInChildren<TMP_Text>().text = difficulties.GetItem(i).Name;
        }
    }
}
