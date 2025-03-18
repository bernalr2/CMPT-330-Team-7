using UnityEngine;

[CreateAssetMenu(fileName = "NewFragmentData", menuName = "Fragment Data")]
public class FragmentData : ScriptableObject
{
    public string FragmentName;
    public string Description;
    public bool isFound;
}
