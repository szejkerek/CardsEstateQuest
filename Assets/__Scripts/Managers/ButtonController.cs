using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Transform buttonContainer; 
    public GameObject buttonPrefab; 

    public string[] levelNames ; 
    public Sprite[] levelIcons; 

    private void Start()
    {
        GenerateLevelButtons();
    }

    void GenerateLevelButtons()
    {
        for (int i = 0; i < levelNames.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, buttonContainer);
            button.GetComponentInChildren<TMP_Text>().text = levelNames[i];

            Transform childTransform = button.transform.Find("Image");
            Image childImage = childTransform.GetComponent<Image>();
            childImage.sprite = levelIcons[i]; 
        }
    }
}
