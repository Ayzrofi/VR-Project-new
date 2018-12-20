using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchScreen : MonoBehaviour {

    public Camera PlayerCam;

    [Range(0, 50)]
    public float upAngle;
    //[Range(0, 50)]
    //public float downAngle;

    // input Android touch 
    public float maxRotationPerSecond = 75f;
    public float mouseRotaionSpeed = 100;
    float verticalLook;
    Rect lookRect;
    int touchID = -1;
    Vector2 TouchOriginal;

    void Start () {
        lookRect = new Rect(Screen.width / 2, 0, Screen.width, Screen.height);

    }


    void Update () {
        TouchInput();

        //mouseInput();
    }

    private void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            if (touchID == -1)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase != TouchPhase.Began)
                        continue;

                    if (!lookRect.Contains(touch.position))
                        continue;

                    touchID = touch.fingerId;
                    TouchOriginal = touch.position;
                    break;
                }
            }
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId != touchID)
                    continue;
                Vector3 touchDistance = touch.position - TouchOriginal;

                //Vector3 ClampRotation = Vector3.ClampMagnitude(new Vector3(-touchDistance.y, touchDistance.x), maxRotationPerSecond);
                //RotateView(ClampRotation);

                transform.Rotate(Vector3.up * touchDistance.x * Time.deltaTime);

                verticalLook += touchDistance.y * Time.deltaTime;
                verticalLook = Mathf.Clamp(verticalLook, -upAngle, upAngle);
                PlayerCam.transform.localEulerAngles = Vector3.left * verticalLook;

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    touchID = -1;
                }
                break;
            }
        }
    }
    //void mouseInput()
    //{
    //    Vector3 Rotation = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
    //    RotateView(Rotation * mouseRotaionSpeed);
    //}

    //private void RotateView(Vector3 Rotasi)
    //{
    //    // rotate the player 
    //    //transform.Rotate(Rotasi * Time.deltaTime);
    //    transform.Rotate(Rotasi * Time.deltaTime);
    //    //PlayerCam.transform.Rotate(Rotasi * Time.deltaTime);

    //    // to riset z transform if gyro input is enable
    //    //if (Input.gyro.enabled)
    //    //{
    //    //    Vector3 LocalEuler = transform.localEulerAngles;
    //    //    transform.localRotation = Quaternion.Euler(LocalEuler.x, LocalEuler.y, 0f);
    //    //}
    //    // add some limit pitch for player input rotations
    //    float PlayerPitch = LimitPitch();
    //    //PlayerCam.transform.rotation = Quaternion.Euler(PlayerCam.transform.localEulerAngles.x, 0, 0);
    //    // apply pitch for player rotations
    //    transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    //}
    //private float LimitPitch()
    //{
    //    float PlayerPitch = PlayerCam.transform.eulerAngles.x;

    //    float maxPichUp = 360 - upAngle;
    //    float maxPichDown = downAngle;

    //    if (PlayerPitch > 100 && PlayerPitch < maxPichUp)
    //    {
    //        PlayerPitch = maxPichUp;
    //    }
    //    else
    //        if (PlayerPitch < 100 && PlayerPitch > maxPichDown)
    //    {
    //        PlayerPitch = maxPichDown;
    //    }

    //    return PlayerPitch;
    //}

}// end classs


















