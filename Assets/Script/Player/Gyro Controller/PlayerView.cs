using UnityEngine;
using System.Collections;
using System;

public class PlayerView : MonoBehaviour {
    [Header("Player Atribute")]
    public Camera PlayerCam;

    [Header("Gyroscope Atribute")]
    public float GyroSpeedRotations = 70f;
    private bool GyroIsEnable;
    //private Gyroscope Gyro;

#if UNITY_EDITOR
    [Header("Mouse Input Atribute")]
    public float mouseRotaionSpeed = 100f;
#endif
    [Header("Pitch Look Limit")]
    [Range(0, 70)]
    public float LimitLookAngle;

    //[Range(0, 50)]
    //public float upAngle;
    //[Range(0, 50)]
    //public float downAngle;
   

    [Header("Touch Screen Atribute")]
    // input Android touch 
    public float TouchScreenSpeed = 1f;
    Rect lookRect;
    int touchID = -1;
    Vector2 TouchOriginal;
    //public float maxRotationPerSecond = 75f;
    // Temp variabel for store value of limit look angle 
    float VerticalLook;

    //private void Start()
    //{
    //    lookRect = new Rect(0, 0, Screen.width /*/ 2*/, Screen.height /** 0.75f*/);
    //}

    private void Awake()
    {
        GyroIsEnable = SystemInfo.supportsGyroscope;
    }
    private void Start()
    {
        if (GyroIsEnable)
        {
            Input.gyro.enabled = true;
        }else
        {
            Input.gyro.enabled = false;
        }

        lookRect = new Rect(Screen.width / 2, 0, Screen.width, Screen.height );
    }

    private void Update()
    {
        if (Input.gyro.enabled)
        {
            GyroInput();
        }

        TouchInput();
#if UNITY_EDITOR
        //input view in unity editor
        mouseInput();
#endif
    }

    //private bool EnableGyro()
    //{
    //    if (SystemInfo.supportsGyroscope)
    //    {
    //        Gyro = Input.gyro;
    //        Gyro.enabled = true;
    //        return true;
    //    }
    //    return false;
    //}

    private void GyroInput()
    {
        Vector3 rotation = Input.gyro.rotationRate * GyroSpeedRotations;
        //RotateView(new Vector3(-rotation.x, -rotation.y, 0f));
        transform.Rotate(Vector3.up * -rotation.y * Time.deltaTime );

        if (Input.gyro.enabled)
        {
            Vector3 LocalEuler = transform.localEulerAngles;
            transform.localRotation = Quaternion.Euler(LocalEuler.x, LocalEuler.y, 0f);
        }

        VerticalLook += rotation.x * Time.deltaTime ;
        VerticalLook = Mathf.Clamp(VerticalLook, -LimitLookAngle, LimitLookAngle);
        PlayerCam.transform.localEulerAngles = Vector3.left * VerticalLook;
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

                transform.Rotate(Vector3.up * touchDistance.x * TouchScreenSpeed * Time.deltaTime);

                VerticalLook += touchDistance.y * TouchScreenSpeed * Time.deltaTime;
                VerticalLook = Mathf.Clamp(VerticalLook, -LimitLookAngle, LimitLookAngle);
                PlayerCam.transform.localEulerAngles = Vector3.left * VerticalLook;
                //Vector3 ClampRotation = Vector3.ClampMagnitude(new Vector3(-touchDistance.y, touchDistance.x), maxRotationPerSecond);

                //RotateView(ClampRotation);

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    touchID = -1;
                }
                break;
            }
        }
    }

#if UNITY_EDITOR
    private void mouseInput()
    {
        //Vector3 Rotation = new Vector3(/*-Input.GetAxis("Mouse Y")*/ 0f, Input.GetAxis("Mouse X"), 0f);
        //RotateView(Rotation * mouseRotaionSpeed);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseRotaionSpeed);

        VerticalLook += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseRotaionSpeed;
        VerticalLook = Mathf.Clamp(VerticalLook, -LimitLookAngle, LimitLookAngle);
        PlayerCam.transform.localEulerAngles = Vector3.left * VerticalLook;
    }
#endif

    //private void RotateView(Vector3 Rotasi )
    //{
    //    // rotate the player 
    //    //transform.Rotate(Rotasi * Time.deltaTime);
    //    transform.Rotate(Rotasi * Time.deltaTime);
    //    //PlayerCam.transform.Rotate(Rotasi * Time.deltaTime);

    //    // to riset z transform if gyro input is enable
    //    if (Input.gyro.enabled)
    //    {
    //        Vector3 LocalEuler = transform.localEulerAngles;
    //        transform.localRotation = Quaternion.Euler(LocalEuler.x, LocalEuler.y, 0f);
    //    }
    //    // add some limit pitch for player input rotations
    //    //float PlayerPitch = LimitPitch();
    //    //PlayerCam.transform.rotation = Quaternion.Euler(PlayerCam.transform.localEulerAngles.x,0,0);
    //    // apply pitch for player rotations
    //    transform.rotation = Quaternion.Euler(PlayerCam.transform.eulerAngles.x, transform.eulerAngles.y, 0);
    //    //transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 0  /*transform.eulerAngles.y*/, 0);

    //}
    //private float LimitPitch()
    //{
    //    float PlayerPitch = transform.eulerAngles.x;

    //    float maxPichUp = 360 - upAngle;
    //    float maxPichDown = downAngle;

    //    if (PlayerPitch > 100 && PlayerPitch < maxPichUp)
    //    {
    //        PlayerPitch = maxPichUp;
    //    } else 
    //        if (PlayerPitch < 100 && PlayerPitch > maxPichDown)
    //    {
    //        PlayerPitch = maxPichDown;
    //    }

    //    return PlayerPitch;
    //}
}
