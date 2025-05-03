using UnityEngine;

public class Building : MonoBehaviour, IInteractable
{
    public BuildingData buildingData;

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        return;
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
        Debug.Log("Interactable Object Area Detected");

        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            //InteractableInRange = interactable;
            //InteractableInRange = interactable;
        }
    }
}
