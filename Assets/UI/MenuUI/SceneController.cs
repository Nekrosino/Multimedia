using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Debug.Log("Scena Glownego menu");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("SettingsScene");
        Debug.Log("Scena ustawien");
    }

    public void LoadAuthors()
    {
        SceneManager.LoadScene("AuthorsScene");
        Debug.Log("Scena z informacjami o autorze");
    }

    public void LoadQuiz1()
    {
        SceneManager.LoadScene("QuizABCDScene");
        Debug.Log("Quiz1");
    }

    public void LoadQuiz2()
    {
        SceneManager.LoadScene("Quiz2Scene");
        Debug.Log("Quiz2");
    }

    public void LoadQuiz3()
    {
        SceneManager.LoadScene("Quiz3Scene");
        Debug.Log("Quiz3");
    }


    public void LoadSelectingQuiz()
    {
        SceneManager.LoadScene("SelectQuizScene");
        Debug.Log("Scena z wyborem rodzaju quizu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Wyszedles z gry");
    }

    public void LoadSummaryScene()
    {
        SceneManager.LoadScene("SummaryScene");
    }
}
