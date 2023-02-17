using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameOver : MonoBehaviour
{
    public Text Score;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Score.text = "Score: " + PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    public void Restart()
    {
        SceneManager.LoadScene("Zorest");
    }
}
