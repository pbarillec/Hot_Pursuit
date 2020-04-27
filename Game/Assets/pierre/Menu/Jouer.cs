using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jouer : MonoBehaviour
{
    public string MapACharger;
    public void PlayGame()
    {
        //UnityEngine.Cursor.visible = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(MapACharger);
    }
}
