using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue DialogueData;
    public GameObject DialoguePanel;
    public TMP_Text DialogueText, NameText;
    public Image PortraitImage;

    public GameObject playerReference;

    private int DialogueIndex;
    private bool IsTyping, IsDialogueActive;

    void Start()
    {
  
    }

    bool IInteractable.CanInteract()
    {
        return !IsDialogueActive;
    }

    void IInteractable.Interact()
    {
        PlayerController player = playerReference.GetComponent<PlayerController>();
        player.PausePlayer();

        Debug.Log("Hello");
        if (DialogueData == null /*|| (PauseController.IsGamePaused && !IsDialogueActive)*/)
        {
            return;
        }
        if (IsDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        IsDialogueActive = true;
        DialogueIndex = 0;

        NameText.SetText(DialogueData.NPCName);
        PortraitImage.sprite = DialogueData.NPCPortrait;

        DialoguePanel.SetActive(true);
        //PauseController.SetPause(true);

        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (IsTyping)
        {
            StopAllCoroutines();
            DialogueText.SetText(DialogueData.DialogueLines[DialogueIndex]);
            IsTyping = false;
        }

        else if (++DialogueIndex < DialogueData.DialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }

        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        IsTyping = true;
        DialogueText.SetText("");

        foreach(char letter in DialogueData.DialogueLines[DialogueIndex])
        {
            DialogueText.text += letter;
            //SoundEffectManager.PlayVoice(DialogueData.VoiceSound, DialogueData.VoicePitch);
            yield return new WaitForSeconds(DialogueData.TypingSpeed);
        }

        IsTyping = false; 

        if (DialogueData.AutoProgressLines.Length > DialogueIndex && DialogueData.AutoProgressLines[DialogueIndex])
        {
            yield return new WaitForSeconds(DialogueData.AutoProgressDelay);
            NextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        IsDialogueActive = false;
        DialogueText.SetText("");
        DialoguePanel.SetActive(false);
        PlayerController player = playerReference.GetComponent<PlayerController>();
        player.PausePlayer();
        //PauseController.SetPause(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Interactable NPC Detected");

        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            //InteractableInRange = interactable;
            //InteractableInRange = interactable;
        }
    }
}
