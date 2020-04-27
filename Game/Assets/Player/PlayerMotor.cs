using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 rotation;
    private Rigidbody rb;
    public  Transform car;
    public float timeStart = 5;
    public int dead;

    // Start is called before the first frame update
    private void Start()
    {
        dead = 0;
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotation(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement()
    {
        PlayerPrefs.SetInt("Dead", dead);
        if (velocity != Vector3.zero) {
            if (car.GetChild(0).position.y > car.position.y)
            {
                Lose();
                return;
            }
            if (car.GetChild(1).position.y > car.position.y)
            {
                Lose();
                return;
            }
            if (car.GetChild(2).position.y > car.position.y)
            {
                Lose();
                return;
            }
            if (car.GetChild(3).position.y > car.position.y)
            {
                Lose();
                return;
            }
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
       if (rotation != Vector3.zero) {
            if (car.GetChild(0).position.y > car.position.y)
                return;
            if (car.GetChild(1).position.y > car.position.y)
                return;
            if (car.GetChild(2).position.y > car.position.y)
                return;
            if (car.GetChild(3).position.y > car.position.y)
                return;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
       }
    }
    private void Lose()
    {
        timeStart -= Time.deltaTime;
        if (timeStart <= 0)
        {
            dead = 1;
            SceneManager.LoadScene("lose");
        }
    }
}