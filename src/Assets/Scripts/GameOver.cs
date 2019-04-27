using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsText;
    bool gameOver;

    void Start()
    {
        //Subscrives the OnGameOver method to the OnPlayerDeath event.
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }

    void Update()
    {
        if (gameOver) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver() {
        gameOverScreen.SetActive(true);
        secondsText.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
