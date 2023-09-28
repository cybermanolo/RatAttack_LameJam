using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPill : MonoBehaviour
{

    [SerializeField] private bool isSpeedBoost;
    [SerializeField] private bool isStrengthBoost;

    [SerializeField] private float speedAmount = 0;
    [SerializeField] private int strengthAmount = 0;
    [SerializeField] private PillSO pillSO;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {

            if (isSpeedBoost)
            {
                collision.GetComponent<PlayerTriggerBehaviour>().initialSpeed += speedAmount;

            }

            if (isStrengthBoost)
            {
                collision.GetComponent<PlayerTriggerBehaviour>().maxWeight += strengthAmount;
            }
            
            Destroy(gameObject);
           // gameObject.SetActive(false);
        }

    }


}
