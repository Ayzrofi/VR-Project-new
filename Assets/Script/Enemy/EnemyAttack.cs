using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float delayAttack;
    public int damageToGive;
    public  bool PlayerInRange = false;

    PlayerHealth P_Health;
    float waktu;
    

    private void Awake()
    {
		P_Health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}

    void Update () {
			waktu += Time.deltaTime;
			if (waktu >= delayAttack && PlayerInRange)
			{
				EnemyHit(); 
			}
	}

    private void EnemyHit()
    {
        waktu = 0;
        P_Health.Damage(damageToGive);
    }
}
