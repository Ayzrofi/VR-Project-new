using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int HealthEnemy;
    [SerializeField]
    int CurrentHealth;
    NavMeshAgent navEnemy;

    public GameObject HealthPickup;

    [HideInInspector]
    public static bool isDead = false;
    public Animator anim;

    private void Start()
    {
        navEnemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        CurrentHealth = HealthEnemy;
    }
    //private void Update()
    //{
    //    if (ItsFallen)
    //    {
    //        transform.Translate(-Vector3.up * FallSpeed * Time.deltaTime);
    //    }   
    //}

    public void StartSinking()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
    
    private void OnEnable()
    {
        CurrentHealth = HealthEnemy;
    }
    public void Damage(int Dmg)
    {
        CurrentHealth -= Dmg;
        if (CurrentHealth <= 0)
        {
            isDead = true;
            anim.SetTrigger("Dead");
            StartCoroutine(enemyDeath());
        }
            
    }

    IEnumerator enemyDeath()
    {
        yield return new WaitForSeconds(.8f);
        Instantiate(HealthPickup, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
