using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    Rigidbody Body;
    public int speed;
    public GameObject SpawnPos;

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
        SpawnPos = GameObject.Find("SpawnPos");
       
    }

    private void Start()
    {
        transform.rotation = SpawnPos.transform.rotation;
        Destroy(gameObject, .5f);
    }

    private void FixedUpdate()
    {
        //Body.MovePosition(Body.position + Vector3.forward * speed * Time.fixedDeltaTime);
        transform.Translate(Vector3.forward *  Time.fixedDeltaTime * speed);
    }
}
