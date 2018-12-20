using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    public int damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var musuh = other.GetComponent<EnemyHealth>();
            musuh.Damage(damage);

        }
    }
}
