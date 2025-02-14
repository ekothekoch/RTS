using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCadle : MonoBehaviour
{
    float mainSpeed = 100.0f; //regular speed
    float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    float camSens = 3f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;
    public bool invertY = true;

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            var mouseMoveY = invertY ? -1 * Input.GetAxis("Mouse Y") : Input.GetAxis("Mouse Y");
            var mouseMoveX = Input.GetAxis("Mouse X");

            var mouseMove = new Vector3(mouseMoveY, mouseMoveX, 0) * camSens;
            transform.eulerAngles = transform.eulerAngles + mouseMove;
        }

        if (Input.GetMouseButtonDown(2))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetMouseButtonUp(2))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //if (Input.GetMouseButton(1))
        //{
        //    lastMouse = Input.mousePosition - lastMouse;
        //    lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        //    lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y);
        //    transform.eulerAngles = lastMouse;
        //    lastMouse = Input.mousePosition;
        //}
        //Mouse  camera angle done.  

        //Keyboard commands
        float f = 0.0f;
        Vector3 p = GetBaseInput();
        if (p.sqrMagnitude > 0)
        { // only move while a direction key is pressed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                totalRun += Time.deltaTime;
                p = p * totalRun * shiftAdd;
                p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
                p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
                p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
            }
            else
            {
                totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
                p = p * mainSpeed;
            }

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
             
             //If player wants to move on X and Z axis only
                transform.Translate(p);
                newPosition.x = transform.position.x;
                newPosition.z = transform.position.z;
                transform.position = newPosition;
            
            
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView++;
        }
    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}

    //float rotationX = 0f;
    //float rotationY = 0f;
    //public float speed = 20;
    //float oldRotationX;
    //float oldRotationY;
    //public float sensitivity = 15f;
    //public float minYAngle = -30f; // Minimum Y-axis rotation angle
    //public float maxYAngle = 30f;  // Maximum Y-axis rotation angle

    //void Update()
    //{
    //    rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle);
    //    //Cursor.lockState = CursorLockMode.Locked;
    //    rotationY += Input.GetAxis("Mouse X") * sensitivity;
    //    rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;

    //    // Clamp the rotationX to limit the Y-axis rotation
       
    //  //  rotationY= Mathf.Clamp(rotationY, minYAngle, -maxYAngle);
    //    if (Input.GetMouseButton(1))
    //    {
    //       Cursor.lockState = CursorLockMode.Confined;
    //      //  transform.localEulerAngles = new Vector3(oldRotationX, oldRotationY, 0);
    //        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    //    }
    //    if(Input.GetMouseButtonUp(1))
    //    {
    //        Cursor.lockState = CursorLockMode.None;
    //       // transform.localEulerAngles = new Vector3( oldRotationX,  oldRotationY, 0);
    //    }
    //    transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime
    //        , Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
    //    if (Input.GetAxis("Mouse ScrollWheel")>0)
    //    {
    //        GetComponent<Camera>().fieldOfView--;
    //    }
    //    if (Input.GetAxis("Mouse ScrollWheel") <0)
    //    {
    //        GetComponent<Camera>().fieldOfView++;
    //    }
    //}





    //// Start is called before the first frame update
    //void Start()
    //{
    //    //oldRotationX=transform.eulerAngles.x;
    //    //oldRotationY = transform.eulerAngles.y;
    
    //    //float rotationX = Camera.main.transform.rotation.x;
    //    //float rotationY = Camera.main.transform.rotation.y;


    //}

