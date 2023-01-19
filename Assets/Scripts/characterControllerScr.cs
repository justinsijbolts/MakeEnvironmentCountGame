using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControllerScr : MonoBehaviour
{

    // Public values
    public float jumpHeight;
    public float speed;
    public float cameraSensitivity;


    // Private values
    private float usedSpeed;


    void Start()
    {
        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        usedSpeed = speed;
    }

    void cameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * cameraSensitivity, 0);

        float mouseY = Input.GetAxis("Mouse Y");
        Camera.main.transform.Rotate(-mouseY * cameraSensitivity, 0, 0);

        // camera rotation Z should always be 0
        Camera.main.transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, 0);
    }

    /*
            float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * cameraSensitivity, 0);
        float mouseY = Input.GetAxis("Mouse Y");
        float currentCameraRotationX = Camera.main.transform.localEulerAngles.x;
    
        if (currentCameraRotationX > 270 || currentCameraRotationX < 90)
        {
            Camera.main.transform.Rotate(-mouseY * cameraSensitivity, 0, 0);
        }
    */

    void playerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, usedSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -usedSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-usedSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(usedSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            usedSpeed = speed * 2;
        } else {
            usedSpeed = speed;
        }

        if (Input.GetKey(KeyCode.Space) && GetComponent<Rigidbody>().velocity.y == 0)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse); 
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }

        // log the velocity y value
        Debug.Log(GetComponent<Rigidbody>().velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        cameraMovement();
    }

    void FixedUpdate() {
        playerMovement();
    }
}
