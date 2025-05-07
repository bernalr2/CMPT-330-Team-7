using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable InteractableInRange = null; // Closest Interactable
    public GameObject ExclamationIcon;
    public GameObject QuestionIcon;
    public GameObject EIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ExclamationIcon.SetActive(false);
        QuestionIcon.SetActive(false);
        EIcon.SetActive(false);
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InteractableInRange?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Interactable Object Area Detected");

        if(collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            InteractableInRange = interactable;
            ExclamationIcon.SetActive(true);
            QuestionIcon.SetActive(true);
            EIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Interactable Object Area Left");
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == InteractableInRange)
        {
            InteractableInRange = null;
            ExclamationIcon.SetActive(false);
            QuestionIcon.SetActive(false);
            EIcon.SetActive(false);
        }
    }
}
