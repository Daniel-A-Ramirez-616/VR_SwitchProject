using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class VRSwitch : MonoBehaviour
{

    [Header("Settings")]
    public GameObject vrPlayerPrefab;      // VR player rig
    public GameObject nonVRPlayerPrefab;   // Non-VR player rig

    private GameObject currentPlayer;


    private void Start()
    {
        // Start in non-VR mode by default
        SwitchToVR();
    }

    // Switch to VR mode
    public void SwitchToVR()
    {
        StartCoroutine(EnableVRCoroutine());
    }

    // Switch to non-VR mode
    public void SwitchToNonVR()
    {
        StartCoroutine(DisableVRCoroutine());
    }

    // Coroutine to enable XR at runtime
    private IEnumerator EnableVRCoroutine()
    {
        Debug.Log("Initializing VR...");
        XRGeneralSettings.Instance.Manager.InitializeLoader();

        // Wait until loader is initialized
        while (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            yield return null;
        }

        XRGeneralSettings.Instance.Manager.StartSubsystems();
        Debug.Log("VR Enabled");

        // Spawn VR player
        if (currentPlayer != null) Destroy(currentPlayer);
        if (vrPlayerPrefab != null) currentPlayer = Instantiate(vrPlayerPrefab);
    }

    // Coroutine to disable XR at runtime
    private IEnumerator DisableVRCoroutine()
    {
        Debug.Log("Stopping VR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("VR Disabled");

        // Spawn non-VR player
        if (currentPlayer != null) Destroy(currentPlayer);
        if (nonVRPlayerPrefab != null) currentPlayer = Instantiate(nonVRPlayerPrefab);

        yield return null;
    }

}
