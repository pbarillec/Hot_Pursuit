using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MoneySpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    private GameObject[] spawn;
    public bool invisible = true;
    void Start()
    {
        spawn = GameObject.FindGameObjectsWithTag("money_spawn_point");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            addMoney();
        }
    }

    void addMoney()
    {
        var money = GameObject.FindGameObjectsWithTag("money");

        for (int i = 0; i < spawn.Length; i++)
        {
            float x_len = 0;
            float y_len = 0;
            float z_len = 0;

            bool new_spawn = true;

            for (int j = 0; j < money.Length; j++)
            {

                x_len = Mathf.Abs(money[j].transform.position.x - spawn[i].transform.position.x);
                y_len = Mathf.Abs(money[j].transform.position.y - spawn[i].transform.position.y);
                z_len = Mathf.Abs(money[j].transform.position.z - spawn[i].transform.position.z);

                if (x_len <= 5 && y_len <= 5)
                {
                    new_spawn = false;
                    break;
                }
            }
            var func = spawn[i].GetComponent<visible>();
            if (new_spawn == true && (func.isVisible() == false ||invisible == false))
                Instantiate(item, spawn[i].transform.position, Quaternion.identity);
        }
    }
}
