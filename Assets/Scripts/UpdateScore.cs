using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{

    [SerializeField]
    BuildHealthBar bar;

    [SerializeField]
    Text scoreText;

    private int score = 0;
    private int energy = 100;

    private int energyConsumedBySingleJump = 10;

    private void Start()
    {
        bar.SetMaxHealth(100);
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            energy -= energyConsumedBySingleJump;
            score += 1;
        }
        ChangeScore();
    }

    public void ChangeScore()
    {
        bar.SetHealth(energy);
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("iceblock"))
        {
            energy -= energyConsumedBySingleJump;
        }
    }



}
