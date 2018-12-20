using UnityEngine;
using System.Collections;

public class EnemySpawnManajer : MonoBehaviour {

    public GameObject Player;
    public PoolerObject[] Enemy;
    //private Vector3 EnemySpawnPos;
    public float ZRandomPos = 20f;
    public int JumlahEnemy,SpawnDistance = 10;
    public float DelaySpawn, WaktuMulai, DelayLevel;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(WaktuMulai);
        while (true)
        {
            for (int i = 0; i < JumlahEnemy; i++)
            {
                int enemySelector = Random.Range(0, Enemy.Length);

                //Vector3 SpawnPos = new Vector3(Random.Range(-EnemySpawnPos.x, EnemySpawnPos.x), EnemySpawnPos.y, Random.Range(ZRandomPos ,EnemySpawnPos.z));
                Vector3 SpawnPos = new Vector3(Player.transform.position.x + Random.Range(-SpawnDistance, SpawnDistance) ,Player.transform.position.y,Player.transform.position.z + SpawnDistance);
                Quaternion SpawnRot = Quaternion.identity;
                //Instantiate(Enemy, SpawnPos, SpawnRot);
                GameObject GO = Enemy[enemySelector].GetPooledObject();
                GO.transform.position = SpawnPos;
                GO.transform.rotation = SpawnRot;
                GO.SetActive(true);
                //Debug.Log(SpawnPos);
                yield return new WaitForSeconds(DelaySpawn);
            }
            JumlahEnemy += 5;
           
            yield return new WaitForSeconds(DelayLevel);
        }
    }
}
