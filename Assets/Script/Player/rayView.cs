using UnityEngine;
using System.Collections;

public class rayView : MonoBehaviour {

    Camera playerCam;
    float jarakTembak = 50f;
    private void Start()
    {
        playerCam = GetComponentInChildren<Camera>();
    }
    private void Update()
    {
        Vector3 liniOrigin = playerCam.ViewportToWorldPoint(new Vector3( 0.5f, 0.5f, 0f));
        Debug.DrawRay(liniOrigin, playerCam.transform.forward * jarakTembak, Color.red);
    }
}
