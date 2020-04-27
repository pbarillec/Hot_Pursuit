using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // You probably want a check here to make sure you're hitting a zombie
        // Note that this is not the best method for doing so.

        if (collision.gameObject.name == "Player")
        {
            int tmp = PlayerPrefs.GetInt("wallet") + 10;
            PlayerPrefs.SetInt("wallet", tmp);
            Destroy(gameObject);
        }
    }
}
