using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
        exitButton.onClick.RemoveListener(QuitGame);
    }

    private void QuitGame()
    {
        Time.timeScale = 1f;

        //Save Player Data Section


        //
        Debug.Log("Çıkış yaptın.");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
    }

    private void StartGame()
    {
        Time.timeScale = 1f;

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Tıkladın");
    }

}
