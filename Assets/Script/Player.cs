using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    public InputActionAsset InputActions;

    private InputAction m_moveAction;
    private InputAction m_lookAction;
    private InputAction m_jumpAction;

    private Vector2 m_moveAmt;
    private Vector2 m_lookAmt;
    private Rigidbody m_Rigidbody;

    public float WalkSpeed = 5;
    public float RotateSpeed = 5;
    public float JumpSpeed = 5;

    private void OnEnable()
    {
        InputActions.FindAction("Player").Enable();
    }
    private void OnDisable()
    {
        InputActions.FindAction("Player").Disable();
    }
    private void Awake()
    {
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_lookAction = InputSystem.actions.FindAction("Look");
        m_jumpAction = InputSystem.actions.FindAction("Jump");
    }
    public void Update()
    {
        m_moveAmt = m_moveAction.ReadValue<Vector2>();
        m_lookAmt = m_lookAction.ReadValue<Vector2>();

        if (m_jumpAction.WasPressedThisFrame())
        {
            Jump();
        }
    }
    public void Jump()
    {
        m_Rigidbody.AddForceAtPosition(new Vector3(0, 5f, 0), Vector3.up, ForceMode.Impulse);
    }
    private void FixedUpdate()
    {
        Walking();
        Rotating();
    }
    public void Walking()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + transform.position * m_moveAmt.y * WalkSpeed * Time.deltaTime);
    }
    public void Rotating()
    {
        if (m_moveAmt.y != 0)
        {
            float rotationAmount = m_lookAmt.x * Time.deltaTime;
            Quaternion deltaRotaion = Quaternion.Euler(0, rotationAmount, 0);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotaion);
        }
    }
}

