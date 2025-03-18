using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class Fragment : MonoBehaviour
{

    public Image fragment;
    public FragmentData fragmentData;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    private bool found;


    public void PointerEnter()
    {
        Debug.Log("Pointer Enter Event Triggered!");
        nameText.text = fragmentData.FragmentName;

        if (!found)
        {
            descriptionText.text = "This fragment has not been found yet...";
        }
        else
        {
            descriptionText.text = fragmentData.Description;
        }
    }

    public void PointerExit()
    {
        Debug.Log("Pointer Exit Event Triggered!");
        descriptionText.text = "";
        nameText.text = "";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        found = fragmentData.isFound;
        if (!found)
        {
            fragment.color = Color.black;
        }
        descriptionText.text = "";
        nameText.text = "";
    }
}
