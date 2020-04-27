using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeStart = 0;
    public Text textBox;

    public string to_load;
    public Transform TargetPlayer;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "SCORE : " + timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Score", timeStart);
        timeStart += Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();
    }
}
