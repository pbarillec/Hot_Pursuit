using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform car;
    Transform rig;
    Camera cam;

    public float cameraStickiness = 10.0f;
    public float rotationThreshold = 1f;
    public float cameraRotationSpeed = 5.0f;

    void Start()
    {
        rig = GetComponent<Transform>();
        cam = rig.GetChild(0).GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion look;

        this.transform.position = Vector3.Lerp(this.transform.position, car.position, cameraStickiness * Time.fixedDeltaTime);

        /*if (car.GetComponent<Rigidbody>().velocity.magnitude < rotationThreshold)
        else
        */    
            look = Quaternion.LookRotation(car.forward);
        //look = Quaternion.LookRotation(car.GetComponent<Rigidbody>().velocity.normalized);

        // Rotate the camera towards the velocity vector.
        look = Quaternion.Slerp(this.transform.rotation, look, cameraRotationSpeed * Time.fixedDeltaTime);
        this.transform.rotation = look;

/*        this.transform.position = car.position;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, car.rotation.eulerAngles.y, 0f));*/
    }
}
