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

    private int energyConsumedBySingleJump = 99;
    private int energyConsumedByLandingOnPlatform = 7;
    private int energy = 100;

    private int score = 0;


    [SerializeField]
    UpdateScore scoreUI;

    [SerializeField]
    GameObject gameOverUI;

    public LayerMask groundLayers;

    private Rigidbody rigidbody;
    private CapsuleCollider collider;
    private Transform transform;

    public int GetEnergy()
    {
        return energy;
    }
    
    public void DecreaseHealth(int amount)
    {
        if (energy <= 0)
        {
            energy = 0;
            return;
        }
        energy -= amount;
        scoreUI.ChangeScore(energy, score);
        Debug.Log(amount);
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        scoreUI.SetInitialScore(100);
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (energy <= 0)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }

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
            DecreaseHealth(energyConsumedBySingleJump);
        }
    }
    
    
    private bool isOnGround()
    {
        return Physics.CheckCapsule(collider.bounds.center,
            new Vector3(collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z), collider.radius *.9f, groundLayers);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            DecreaseHealth(energyConsumedByLandingOnPlatform);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Platform"))
    //    {
    //        other.isTrigger = false;
    //        energy -= energyConsumedBySingleJump;
    //    }
    //}
}
