using UnityEngine;
using UnityEngine.InputSystem;

public class WalekInput : MonoBehaviour
{
    public int playerNumber = 1;
    public float rotationRate = 180f;

    public float moveSpeed = 5f;

    InputData input;
    Rigidbody rb;

    Vector2 leftThumbStick = Vector2.zero;
    Vector2 rightThumbStick = Vector2.zero;
    bool northButton = false;
    bool southButton = false;
    bool eastButton = false;
    bool westButton = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput(playerNumber);
        rb.linearVelocity = Vector3.zero;

        MovePlayer(leftThumbStick.y);

        RotatePlayer(rightThumbStick.x);
    }
    void MovePlayer(float value)
    {

        rb.linearVelocity = gameObject.transform.forward * moveSpeed * value;

    }

    void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(Vector3.up * rotationRate * Time.deltaTime * value);
    }

    public void GetInput(int PlayerInputNumber)
    {
        if (PlayerInputNumber == 0)
        {
            GetInputPlayer0();
        }

    }
    public void clearInputs()
    {
        Vector2 leftThumbStick = Vector2.zero;
        Vector2 rightThumbStick = Vector2.zero;
        bool northButton = false;
        bool southButton = false;
        bool eastButton = false;
        bool westButton = false;
    }
    public void GetInputPlayer0()
    {
        clearInputs();

        Gamepad gpad = Gamepad.current;
        if (gpad != null)
        {
            leftThumbStick = gpad.leftStick.ReadValue();
            rightThumbStick = gpad.rightStick.ReadValue();
            northButton = gpad.buttonNorth.wasPressedThisFrame;
            southButton = gpad.buttonSouth.wasPressedThisFrame;
            eastButton = gpad.buttonEast.wasPressedThisFrame;
            westButton = gpad.buttonWest.wasPressedThisFrame;
        }

    }
}
