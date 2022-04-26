using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI loadingText,systemID;
    void Start()
    {
        systemID.text = "System ID: " + SystemInfo.deviceUniqueIdentifier;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        loadingText.gameObject.SetActive(true);
       

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
