using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 100;
    [SerializeField]
    private float rotation_sensibility = 2;

    private PlayerMotor motor;
    private float x = 0;
    private float y = 0;
    private Rigidbody rb;

    private int modeleCar;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        motor = GetComponent<PlayerMotor>();
        modeleCar = PlayerPrefs.GetInt("Car");
        rb.transform.GetChild(0).gameObject.SetActive(true);
        rb.transform.GetChild(1).gameObject.SetActive(false);
        rb.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void Update()
    {
        // Pickup
        if (modeleCar == 1)
        {
            rb.transform.GetChild(0).gameObject.SetActive(true);
            rb.transform.GetChild(1).gameObject.SetActive(false);
            rb.transform.GetChild(2).gameObject.SetActive(false);
        }
        // Voiture sport
        else if (modeleCar == 2)
        {
            rb.transform.GetChild(0).gameObject.SetActive(false);
            rb.transform.GetChild(1).gameObject.SetActive(false);
            rb.transform.GetChild(2).gameObject.SetActive(true);
        }
        // Camion
        else if (modeleCar == 3)
        {
            rb.transform.GetChild(0).gameObject.SetActive(false);
            rb.transform.GetChild(1).gameObject.SetActive(true);
            rb.transform.GetChild(2).gameObject.SetActive(false);
        }
        // Movement du joueur
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        // y =
        // -> si -1 recule
        // -> si 1 avance
        Vector3 _moveVertical = transform.forward * 1;
        //Vector3 _moveHorizontal = transform.forward * x;
        Vector3 _velocity = (_moveVertical) * speed;

        // Rotation du joueur
        // rotation = 
        // -> si -1 va a droite
        // -> si 1 va a gauche
        float rotation = 0;
        //Input.GetAxis("Horizontal");
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                rotation = 1;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                rotation = -1;
            }
        }
        Vector3 _rotation = new Vector3(0, rotation, 0) * rotation_sensibility;
        motor.Rotation(_rotation * -1);
        motor.Move(_velocity);
    }
}