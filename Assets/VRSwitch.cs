using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;   // NEW input system
using TMPro;

public class VRSwitch : MonoBehaviour
{
    public GameObject vrRig;
    public Camera normalCamera;
    public TMP_Text buttonLabel;

    private bool vrEnabled = false;

    void Start()
    {
        SetVRMode(false);
    }

    void Update()
    {
        // Keyboard shortcut using NEW INPUT SYSTEM
        if (Keyboard.current != null && Keyboard.current.vKey.wasPressedThisFrame)
        {
            ToggleVR();
        }
    }

    public void ToggleVR()
    {
        SetVRMode(!vrEnabled);
    }

    public void SetVRMode(bool enableVR)
    {
        vrEnabled = enableVR;

        vrRig.SetActive(enableVR);
        normalCamera.gameObject.SetActive(!enableVR);

        XRSettings.enabled = enableVR;

        if (buttonLabel != null)
            buttonLabel.text = enableVR ? "Exit VR" : "Enter VR";

        Debug.Log("VR Mode: " + (enableVR ? "Enabled" : "Disabled"));
    }
}