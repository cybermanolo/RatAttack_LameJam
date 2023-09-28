using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestProperties : MonoBehaviour
{

    public int finalScore = 0;
    public int foodScore = 0;
    public int nbBabies = 4;

    public static NestProperties Nest { get; private set; }

    private void Awake()
    {
        Nest = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        foodScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(nbBabies == 0)
        {
            TimerGameOver.Instance.GameOver();
        }
    }

    public void FinalScore() 
    {
        if (nbBabies > 0)
        {
            finalScore = foodScore * nbBabies;
        }
        else
        {
            finalScore = foodScore;
        }
        
    }
}
