using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationRate = 180.0f;
    Vector2 rightThumbStick = Vector2.zero;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LookVertical(float value)
    {
        gameObject.transform.Rotate(value * Vector3.right * rotationRate * Time.deltaTime);
    }
}
