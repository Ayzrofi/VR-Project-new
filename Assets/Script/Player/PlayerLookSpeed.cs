using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookSpeed : MonoBehaviour {

    public PlayerView lookPlayer;


    public void SetGyroSpeed(float LookSpeed)
    {
        lookPlayer.GyroSpeedRotations = LookSpeed;
    }

    public void SetTouchScreenSpeed(float LookSpeed)
    {
        lookPlayer.TouchScreenSpeed = LookSpeed;
    }
}
