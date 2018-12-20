using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour {

    Transform Target;
    NavMeshAgent NavMesh;
    EnemyAttack enemyattack;
  
    public float AttackDistance;

    private void Awake()
    {
        NavMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyattack = GetComponent<EnemyAttack>();
    }
    void Update () {
        if (Target == null || !NavMesh.isOnNavMesh)
        {
            gameObject.SetActive(false);
            return;
        }
        NavMesh.SetDestination(Target.position);
        if (Vector3.Distance(transform.position, Target.position) < AttackDistance )
        {
            NavMesh.Stop();
            enemyattack.PlayerInRange = true;
        } else
        {
            NavMesh.Resume();
            enemyattack.PlayerInRange = false;
        }
	}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player Trigger")
    //    {
    //        NavMesh.Stop();
    //        enemyattack.PlayerInRange = true;
    //    }
    //}
    private void OnDisable()
    {
        enemyattack.PlayerInRange = false;
    }
}
