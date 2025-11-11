using UnityEngine;
using UnityEngine.InputSystem;

public class RigidBodyTankMovement : MonoBehaviour
{

    public int playerInputNumber = 1;

    public float moveSpeed = 5;
    public float rotateSpeed = 100;
    public float MaxVelocity = 15;

    public GameObject camera;

    //InputVariables
    bool northMovement = false;
    bool southMovement = false;
    bool eastMovement = false;
    bool westMovement = false;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (!rb)
        {
            Debug.LogError("No Rigidbody on " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDistance = Vector3.zero;

        CheckInput(playerInputNumber);

        //Stop movement right away, only have movement when there's input
        rb.linearVelocity = Vector3.zero;

        if (northMovement)
        {
            MovePlayer(1.0f);
        }

        if (southMovement)
        {
            MovePlayer(-1.0f);
        }

        if (eastMovement)
        {
            MovePlayerX(-1.0f);
        }

        if (westMovement)
        {
            MovePlayerX(1.0f);
        }
    }
    void MovePlayer(float value)
    {
        rb.linearVelocity = (value * moveSpeed * gameObject.transform.forward);
    }
    void MovePlayerX(float value)
    {
        rb.linearVelocity = (value * moveSpeed * gameObject.transform.right);
    }
    void MovePlayerSpace(float value)
    {
        rb.linearVelocity += (value * moveSpeed * gameObject.transform.forward);

        if (rb.linearVelocity.magnitude >= MaxVelocity)
        {
            rb.linearVelocity = (rb.linearVelocity.normalized * MaxVelocity);
        }
    }
    void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(value * rotateSpeed * Time.deltaTime * Vector3.up);
    }
    void CheckInput(int inputNumber)
    {
        if (inputNumber == 1) { CheckInputP1(); return; }
    }
    void CheckInputP1()
    {
        Keyboard kb = Keyboard.current;
        if (kb != null)
        {
            northMovement = kb.wKey.isPressed;
            southMovement = kb.sKey.isPressed;
            eastMovement = kb.aKey.isPressed;
            westMovement = kb.dKey.isPressed;
        }
    }
    public void LookPlayer(float value)
    {
        //Call LookVertical function in RotateCamera and send value
        RotateCamera rotateCamera = camera.GetComponent<RotateCamera>();
        rotateCamera.LookVertical(value);
    }
}
