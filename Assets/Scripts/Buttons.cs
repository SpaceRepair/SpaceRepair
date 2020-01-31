using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class Buttons : MonoBehaviour
{
    public float VerticalAxis = 0f;
    public float HorizontalAxis = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Application.platform == RuntimePlatform.Android)
        // {
        //     VerticalAxis = CrossPlatformInputManager.GetAxis("Vertical");
        //     HorizontalAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        // }
        // else
        // {
            VerticalAxis = Input.GetAxis("Vertical");
            HorizontalAxis = Input.GetAxis("Horizontal");
        // }
    }

    public void MoveUp()
    {
        VerticalAxis = 1;
    }

    public void NoMoveUp()
    {
        VerticalAxis = 0;
    }

    public void MoveRight()
    {
        HorizontalAxis = 1;
    }

    public void NoMoveRight()
    {
        HorizontalAxis = 0;
    }

    public void MoveDown()
    {
        VerticalAxis = -1;
    }

    public void NoMoveDown()
    {
        VerticalAxis = 0;
    }

    public void MoveLeft()
    {
        HorizontalAxis = -1;
    }

    public void NoMoveLeft()
    {
        HorizontalAxis = 0;
    }
}
