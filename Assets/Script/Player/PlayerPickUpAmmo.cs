//Header
//using System;
using UnityEngine;
//the class monobehavior
public class PlayerPickUpAmmo : MonoBehaviour {
    //camera dari player
    Camera P_cam;
    //jarak dari player ke game objek
    float JarakTembak = 50f;
    //delay pick up peluru
    public float PickUpAmmoDellay = 5f;
    //delay pick up health ammo
    public float PickUpHealthDellay = 3f;
    //timer untuk pick up 
    public float PickUpTime;
    //untuk mengambil value dari player health
    PlayerHealth P_Health;
    //untuk mengambil value dari Player Shot Script
    PlayerShoot Pshoot;

    private void Awake()
    {
        //ambil refrensi dari view camera player
        P_cam = Camera.main;
        //refrensi dari component player health
        P_Health = GetComponent<PlayerHealth>();
        Pshoot = GetComponent<PlayerShoot>();
    }

    private void Update()
    {
        //memanggil function untuk pick up ammo
        PickAmmo();    
    }
    //function untuk pick up ammo
    private void PickAmmo()
    {
        // menggambar raycast dari tengah view camera si player
        Vector3 rayOriginal = P_cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        //var raycast
        RaycastHit hit;

        //PickUpTime += Time.deltaTime;
        // memeriksa apakah raycast mengenai sebuah gameobject
        if (Physics.Raycast(rayOriginal, P_cam.transform.forward, out hit, JarakTembak))
        {

            if (hit.collider.tag == "Peluru" )
            {
                //memulai timer untuk pick up game object
                PickUpTime += Time.deltaTime;
                if (PickUpTime >= PickUpAmmoDellay)
                {
                    //meriset kembali timer 
                    PickUpTime = 0;
                    //menambahkan value pada current ammo
                    Pshoot.P_Ammo += 1;
                    Pshoot.AmmoText.text = "Ammo :" + Pshoot.P_Ammo;
                    //destroy this
                    Destroy(hit.collider.gameObject);
                } 
            } else
            
            if (hit.collider.tag == "HealthAmmo")
            {
                //memulai timer untuk pick up game object
                PickUpTime += Time.deltaTime;
                if (PickUpTime >= PickUpHealthDellay)
                {
                    PickUpTime = 0;
                    P_Health.TambahDarah(5);
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                PickUpTime = 0;
            }
        }
        //Debug.DrawRay(liniOrigin, playerCam.transform.forward * jarakTembak, Color.red);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Peluru")
        {
            Pshoot.P_Ammo += 1;
            Pshoot.AmmoText.text = "Ammo :" + Pshoot.P_Ammo;
            //destroy this
            Destroy(other.gameObject);
        }
        if (other.tag == "HealthAmmo")
        {
            P_Health.TambahDarah(5);
            Destroy(other.gameObject);
        }
    }
}
