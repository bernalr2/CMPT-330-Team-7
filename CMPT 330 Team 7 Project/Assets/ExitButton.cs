using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public AudioSource KeyboardClick;
    public void OnClick()
    {
        KeyboardClick.Play();
        SceneManager.LoadScene("Main Menu");
    }
}
