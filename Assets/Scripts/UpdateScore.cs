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

    private void Start()
    {
        bar.SetMaxHealth(100);
        scoreText.text = score.ToString();
    }

    public void ChangeScore(int energy, int score)
    {
        bar.SetHealth(energy);
        scoreText.text = score.ToString();
    }

    public void SetInitialScore(int energy)
    {
        bar.SetMaxHealth(energy);
    }




}
