using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue DialogueData;
    public GameObject DialoguePanel;
    public TMP_Text DialogueText, NameText;
    public Image PortraitImage;

    private int DialogueIndex;
    private bool IsTyping, IsDialogueActive;

    bool IInteractable.CanInteract()
    {
        return !IsDialogueActive;
    }

    void IInteractable.Interact()
    {
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

        NameText.SetText(DialogueData.name);
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
            SoundEffectManager.PlayVoice(DialogueData.VoiceSound, DialogueData.VoicePitch);
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
        //PauseController.SetPause(false);
    }
}
