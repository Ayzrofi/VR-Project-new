using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Animations;
using System.Collections;
using System;
//using System;

public class PlayerShoot : MonoBehaviour {

    public int gunDamage;
    public float FireDelay;
    public float JarakTembak;

    public int P_Bullet ;
    int P_CurrentBullet;
    public Text BulletText;

    int PlayerAmmo;
    public  int P_Ammo;
    public Text AmmoText;
    //public float fireForce;
    //public Transform gunEnd;

    Camera PlayerCam;
    //public LineRenderer ShootLine;
    //WaitForSeconds ShootDurasi = new WaitForSeconds(.07f);

    float nextFire;
    public Animation CrosshairAnim;

    PlayerHealth P_Health;

    public AudioSource PlayerSound;
    public AudioClip GunSound;

    public void Awake()
    {
        //P_Health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        PlayerCam = Camera.main;
        //ShootLine = GetComponentInChildren<LineRenderer>();
        //CrosshairAnim = GetComponent<Animation>();
       
        AmmoText.text = "Ammo :" + P_Ammo;
        P_CurrentBullet = P_Bullet;
        BulletText.text = "Bullet :" + P_CurrentBullet;
    }

    
    private void Update()
    {
        //P_Bullet = P_CurrentBullet;
        //PlayerAmmo = P_Ammo;

        if (Input.GetKeyDown(KeyCode.F) && Time.time > nextFire && P_CurrentBullet > 0)
        {
            OnMobileShoot();
           
        }

        if (Input.GetKeyDown(KeyCode.R) || P_CurrentBullet <= 0)
        {
            Reload(10);
        }
        
       
    }

    private void Reload(int AddSomeBullet)
    {
        if(P_Ammo > 0)
        {
            P_CurrentBullet += AddSomeBullet;
            BulletText.text = "Bullet :" + P_CurrentBullet;
            if (P_CurrentBullet > P_Bullet)
            {
                P_CurrentBullet = P_Bullet;
                BulletText.text = "Bullet :" + P_CurrentBullet;
            }
            P_Ammo--;
            AmmoText.text = "Ammo :" + P_Ammo;
        }
    }

    public void OnMobileShoot()
    {
        if (Time.time > nextFire && P_CurrentBullet > 0)
        {
            PlayerSound.PlayOneShot(GunSound);
            nextFire = Time.time + FireDelay;
            CrosshairAnim.Play("Crosshair");
            P_CurrentBullet -= 1;
            BulletText.text = "Bullet :" + P_CurrentBullet;
            //StartCoroutine(ShootEffect());
            Shooting();
        }
        else
            return;
       
    }
    private void Shooting()
    {
        Vector3 rayOriginal = PlayerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));

        Debug.DrawRay(rayOriginal, PlayerCam.transform.forward * JarakTembak, Color.red);

        RaycastHit hit;

        //ShootLine.SetPosition(0, gunEnd.position);

        if (Physics.Raycast(rayOriginal, PlayerCam.transform.forward, out hit, JarakTembak))
        {
            //ShootLine.SetPosition(1, hit.point);
            //EnemyHealth H_enemy = hit.collider.GetComponent<EnemyHealth>();
            EnemyHealth H_enemy = hit.transform.GetComponent<EnemyHealth>();
            EnemyHealth HeadEnemy = hit.transform.GetComponentInParent<EnemyHealth>();
            //NavMeshAgent NavEnemy = hit.collider.GetComponent<NavMeshAgent>() ;

            if (H_enemy != null || HeadEnemy!= null)
            {
                if (hit.transform.tag == "Enemy")
                {
                    H_enemy.Damage(gunDamage);
                }

                if (hit.transform.tag == "Head")
                {
                    HeadEnemy.Damage(10);
                }
            }


            //if (hit.transform.tag == "HealthAmmo")
            //{
            //    P_Health.TambahDarah(5);
            //    Destroy(hit.transform.gameObject);
            //}
            //if (NavEnemy != null)
            //    NavEnemy.speed *= 5;

           
        }
        //else
        //{
        //    //ShootLine.SetPosition(1, rayOriginal + (PlayerCam.transform.forward * JarakTembak));
        //}
    }

    //IEnumerator ShootEffect()
    //{

    //    ShootLine.enabled = true;
    //    yield return ShootDurasi;
    //    ShootLine.enabled = false;
    //}
}
