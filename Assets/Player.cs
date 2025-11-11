using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    InputData input;
    public int inputNumber = 0;
    public float moveSpeed = 2.0f;
    public float rotationRate = 180.0f;

    public GameObject camera;

    VRSwitch vR;

    //Controller inputs
    //face
    bool northButton = false;
    bool southButton = false;
    bool eastButton = false;
    bool westButton = false;
    //dpad
    bool upButton = false;
    bool downButton = false;
    bool leftButton = false;
    bool rightButton = false;
    //triggers
    bool topRightTrigger = false;
    bool bottomRightTrigger = false;
    bool topLeftTrigger = false;
    bool bottomLeftTrigger = false;
    //control sticks
    Vector2 leftThumbStick = Vector2.zero;
    bool leftThumbStickButton = false;
    Vector2 rightThumbStick = Vector2.zero;
    bool rightThumbStickButton = false;

    Rigidbody rb;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputNumber = ApplicationManager.application.GetPlayerNumber();
        input = InputPoller.reference.GetInput(inputNumber);
        //Get input number to determine method of control 0- controller 1- keyboard
        rb.linearVelocity = Vector3.zero;

        MovePlayer(input.leftStick);
        RotatePlayer(input.rightStick.x);
        LookPlayer(input.rightStick.y * -1);
    }
    /// <summary>
    /// Work horse function to move the player via RigidBody
    /// </summary>
    /// <param name="value"></param>
    public void MovePlayer(Vector2 value)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection += value.y * gameObject.transform.forward;
        moveDirection += value.x * gameObject.transform.right;

        // need to mormalize to keep movement at rate of 1 relative to input. 
        rb.linearVelocity = (moveDirection.normalized * moveSpeed);
    }

    /// <summary>
    /// Overloaded version of Move Player that takes floats. Formats it into a vector 2 and calls the workhorse function 
    /// This exists to make writiting our code easier. 
    /// </summary>
    /// <param name="valuex"></param>
    /// <param name="valuey"></param>
    public void MovePlayer(float valuex, float valuey)
    {
        MovePlayer(new Vector2(valuex, valuey));
    }

    public void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(value * Vector3.up * rotationRate * Time.deltaTime);
    }

    public void LookPlayer(float value)
    {
        //Call LookVertical function in RotateCamera and send value
        RotateCamera rotateCamera = camera.GetComponent<RotateCamera>();
        rotateCamera.LookVertical(value);
    }

}

