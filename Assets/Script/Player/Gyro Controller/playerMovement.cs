using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public float speed;
    public Rigidbody rb;
    public AnalogController MobileController;
    Vector3 movement;

    public void Update()
    {
        movement = moveVector();
        MoveForce();
        //float horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        //float vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;


        //Vector3 movement = new Vector3(horizontal, 0f, vertical);

        //movement = rb.velocity;
        //movement.x =MobileController.horizontal();
        //movement.z =MobileController.vertical();
        //transform.Translate(movement);
        
        //rb.velocity = movement;
        //Debug.Log(movement);

        //rb.velocity = new Vector3(horizontal, 0f, vertical);
    }

    private void MoveForce()
    {
        transform.Translate((movement * speed) * Time.deltaTime);
        //rb.AddForce(movement * speed);
    }

    private Vector3 moveVector()
    {
        Vector3 dir = Vector3.zero;
        dir.x = MobileController.horizontal();
        dir.z = MobileController.vertical();

        if (dir.magnitude > 1.0f)
            dir.Normalize();

        return dir;
    }
}
