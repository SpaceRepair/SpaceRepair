using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class Buttons : MonoBehaviour
{
    public float VerticalAxis = 0f;
    public float HorizontalAxis = 0f;

    public bool touchControlEnabled = false;

    public GameObject joystick;
    public GameObject buttonForAndroid;

    // Start is called before the first frame update
    void Start()
    {
        joystick.SetActive(false);
        buttonForAndroid.SetActive(false);

        #if UNITY_ANDROID
            ShowMobileInput();
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        if (touchControlEnabled)
        {
            var joy = GameObject.Find("Joystick").GetComponent<bl_Joystick>();
            VerticalAxis = 0.2f * joy.Vertical;
            HorizontalAxis = 0.2f * joy.Horizontal;
        }
        else
        {
            VerticalAxis = Input.GetAxis("Vertical");
            HorizontalAxis = Input.GetAxis("Horizontal");
        }
        if (Input.GetKeyDown("escape"))
        {
            GameRestart();
        }
    }

    public void ShowMobileInput()
    {
        touchControlEnabled = true;
        joystick.SetActive(true);
        buttonForAndroid.SetActive(true);
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

    public void GameRestart()
    {
        Time.timeScale = 1F;
        Application.LoadLevel(Application.loadedLevel);
    }
}
