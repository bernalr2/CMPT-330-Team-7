using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Building : MonoBehaviour, IInteractable
{
    public BuildingData buildingData;
    public GameObject decisionPanel;
    public TMP_Text decisionText;

    public GameObject playerReference;

    private bool isPanelActive;

    public bool CanInteract()
    {
        return !isPanelActive;
    }

    public void Interact()
    {

        if (isPanelActive)
        {
            return;
        }
        else
        {
            StartDecision();
        }
    }

    void StartDecision()
    {
        PlayerController player = playerReference.GetComponent<PlayerController>();
        player.PausePlayer();
        isPanelActive = true;
        decisionPanel.SetActive(true);
        decisionText.SetText("Would you like to enter the " + buildingData.BuildingName + "?");
    }

    public void ClosePanel()
    {
        PlayerController player = playerReference.GetComponent<PlayerController>();
        player.PausePlayer();
        isPanelActive = false;
        decisionPanel.SetActive(false);
    }

    public void EnterBuilding()
    {
        Debug.Log("Entering building: " + buildingData.BuildingName);

        // Load courtroom
        if (buildingData.BuildingScene == "Courtroom")
        {
            SceneManager.LoadScene("Courtroom", LoadSceneMode.Single);
        }
        // If Scene is not officially added to any of the buildings, load Placeholder
        else
        {
            SceneManager.LoadScene("Placeholder", LoadSceneMode.Single);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Interactable Building Detected");

        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            //InteractableInRange = interactable;
            //InteractableInRange = interactable;
        }
    }
}
