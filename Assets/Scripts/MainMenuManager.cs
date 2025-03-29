using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject homePage;
    public GameObject settingsPage;
    public GameObject howToPlayPage;
    public GameObject aboutPage;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with the name of your game scene.
    }

    public void OpenSettings()
    {
        homePage.SetActive(false);
        settingsPage.SetActive(true);
    }

    public void OpenHowToPlay()
    {
        homePage.SetActive(false);
        howToPlayPage.SetActive(true);
    }

    public void OpenAbout()
    {
        homePage.SetActive(false);
        aboutPage.SetActive(true);
    }

    public void BackToHome()
    {
        settingsPage.SetActive(false);
        howToPlayPage.SetActive(false);
        aboutPage.SetActive(false);
        homePage.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // For testing in the Unity Editor.
#endif
    }
}
