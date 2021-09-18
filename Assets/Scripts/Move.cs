using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int timesJumped = 0;
    
    private float speed = 0.8f;
    private float jumpForcce = 0.03f;
    private bool playerJumped = false;

    public LayerMask groundLayers;


    private Rigidbody rigidbody;
    private CapsuleCollider collider;
    private Transform transform;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        float moveHorizontal = 0;//Input.GetAxis("Horizontal");
        float moveVertical = 0;//Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rigidbody.AddForce(movement*speed);
        if (Input.GetButton("Jump") && isOnGround())
        {
            playerJumped = true;
            rigidbody.AddForce(Vector3.up*jumpForcce, ForceMode.Impulse);
        }
        
        if (Input.GetButtonUp("Jump") && playerJumped)
        {
            playerJumped = false;
            timesJumped++;
        }
    }
    
    
    private bool isOnGround()
    {
        return Physics.CheckCapsule(collider.bounds.center,
            new Vector3(collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z), collider.radius *.9f, groundLayers);
    }
}
