using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class end_game : MonoBehaviour
{

    public string to_load;
    public Text textBox;

    void Update()
    {
        float score = PlayerPrefs.GetFloat("Score");
        textBox.text = "SCORE : " + Mathf.Round(score).ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(to_load);
        }
    }
}
