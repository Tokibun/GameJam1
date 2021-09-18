using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 0.8f;
    private float jumpForcce = 0.03f;
    
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rigidbody.AddForce(movement*speed);
        if (Input.GetButton("Jump") && isOnGround())
        {
            rigidbody.AddForce(Vector3.up*jumpForcce, ForceMode.Impulse);
        }
    }

    private bool isOnGround()
    {
        return Physics.CheckCapsule(collider.bounds.center,
            new Vector3(collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z), collider.radius *.9f, groundLayers);
    }
}
    
