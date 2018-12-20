using UnityEngine;
using System.Collections;

public class EnemyMoveAI : MonoBehaviour {
    public GameObject Player;
    public float jarakTarget;
    public float JarakAktif;
    //public GameObject TheEnemy;
    public float EnemyMoveSpeed;
    public int isAtacking;
    RaycastHit hit;

    private void Update()
    {
        transform.LookAt(Player.transform);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            jarakTarget = hit.distance;
            if (jarakTarget < JarakAktif)
            {
                EnemyMoveSpeed = 0.05f;
                if (isAtacking == 0)
                {
                    // play the move animations  karena ga ada aimasi x ya ga usah 
                    transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, EnemyMoveSpeed);
                }
            }
            else
            {
                EnemyMoveSpeed = 0f;
                //play the idle ainimations 
            }

        }
        if (isAtacking == 1)
        {
            // play the attack animations 
            EnemyMoveSpeed = 0f;
        }
    }

    private void OnTriggerEnter()
    {
        isAtacking = 1;
    }
    private void OnTriggerExit()
    {
        isAtacking = 0;
    }
}
