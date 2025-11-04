using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputSystemExample : MonoBehaviour
{
    public Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Keyboard kb = Keyboard.current;
        Mouse mouse = Mouse.current;
        Gamepad gPad = Gamepad.current;

        if (kb.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("New Input system  says space bar is pressed");
        }

        if (mouse.leftButton.wasPressedThisFrame)
        {
            Debug.Log("New Input system  says left mouse is pressed");
        }

        mousePosition = mouse.position.value;



        //Devices are not components
        if (gPad != null)
        {
            bool north = gPad.buttonNorth.wasPressedThisFrame;
            if (north)
            {
                Debug.Log("NorthButton was pressed on Gamepad");
            }
        }
        else
        {
            //Debug.Log("No Gamepad");
        }



    }
}
