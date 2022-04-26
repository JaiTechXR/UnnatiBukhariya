using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject player;
    bool gameEnded = false;
    public AudioClip loseSound;
    public TextMeshProUGUI loseText;
    public float RestartDelay = 3f;
    Camera cam;
    public void KillPlayer()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            
            AudioSource.PlayClipAtPoint(loseSound, transform.position,4);
            loseText.gameObject.SetActive(true);
            Invoke("Restart", RestartDelay);
        }
        
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
