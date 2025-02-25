using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCDialogue", menuName ="NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    public string NPCName;
    public Sprite NPCPortrait;
    public string[] DialogueLines;
    public bool[] AutoProgressLines;
    public float AutoProgressDelay = 1.5f;
    public float TypingSpeed = 0.05f;
    public AudioClip VoiceSound;
    public float VoicePitch = 1f;
}
