using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TabsController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;
    public Color originalColor;
    public Color savedColor;
    public AudioSource PaperFold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {      
        ActivateTab(0);
    }

    public void ActivateTab(int tabNo)
    {
        PaperFold.Play();
        for(int i = 0; i < pages.Length; i++)
        {
            switch(i)
            {
                case 0:
                    originalColor = Color.yellow;
                    break;
                case 1:
                    originalColor = Color.red;
                    break;
                case 2:
                    originalColor = Color.green;
                    break;
                case 3:
                    originalColor = Color.blue;
                    break;
            }
            pages[i].SetActive(false);
            tabImages[i].color = new Color(originalColor.r * 0.5f, originalColor.g * 0.5f, originalColor.b * 0.5f);
        }
        pages[tabNo].SetActive(true);
        tabImages[tabNo].color = new Color(tabImages[tabNo].color.r / 0.5f, tabImages[tabNo].color.g / 0.5f, tabImages[tabNo].color.b / 0.5f);
    }
}
