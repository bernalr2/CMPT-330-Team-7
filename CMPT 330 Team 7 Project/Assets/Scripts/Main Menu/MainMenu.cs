using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnInvestigateButton()
    {
        SceneManager.LoadScene("The Investigation", LoadSceneMode.Single);
    }

    public void OnQuestionButton()
    {
        SceneManager.LoadScene("The Questioning", LoadSceneMode.Single);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
