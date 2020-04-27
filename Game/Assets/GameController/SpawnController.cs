using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;

    public int difficulty = 1;
    public int max_car;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    private GameObject[] spawn;
    public bool invisible = true;
    void Start()
    {
        spawn = GameObject.FindGameObjectsWithTag("spawn_point");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            addCar();
        }
    }

    void addCar()
    {
        var car = GameObject.FindGameObjectsWithTag("police_car");
        int nb_car = car.Length;


        if (nb_car >= max_car)
            return;
        for (int i = 0; i < spawn.Length; i++)
        {
            bool new_spawn = true;

 

            for (int j = 0; j < car.Length; j++)
            {
                float x_len = Mathf.Abs(car[j].transform.position.x - spawn[i].transform.position.x);
                float z_len = Mathf.Abs(car[j].transform.position.z - spawn[i].transform.position.z);

 

                if (x_len <= 10 && z_len <= 10)
                {
                    new_spawn = false;
                    break;
                }
            }
            if (new_spawn == false)
                continue;
            if (UnityEngine.Random.Range(0, 100) <= difficulty)
            {
                var func = spawn[i].GetComponent<visible>();
                int j = 0;
                if (func.isVisible() == false || invisible == false)
                {
                    Instantiate(myPrefab, spawn[i].transform.position, Quaternion.identity);
                    nb_car++;
                }
                
                if (nb_car >= max_car)
                    return;
            }
        }
    }

    void setDifficulty(int value)
    {
        if (value <= 1)
            value = 1;
        difficulty = value;
    }

    int getDifficulty()
    {
        return difficulty;
    }
}
