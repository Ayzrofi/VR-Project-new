using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public GameObject Bullet;
    public Transform BulletSpawnPos;
    float NextFire;
    public float fireDelay;

    void Update () {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (Time.time > NextFire)
        {
            NextFire = Time.time + fireDelay;
            Instantiate(Bullet, BulletSpawnPos.transform.position, Quaternion.identity);
        }
       
    }
}
