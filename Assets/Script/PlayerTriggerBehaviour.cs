using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggerBehaviour : MonoBehaviour
{

    public int carriedWeight = 0;
    public int maxWeight = 6;

    public int score = 0;

    public float initialSpeed;
    public float midSpeed;
    public float slowSpeed;
    
    private bool _ratIsAngry;

    public Player player;

    public TextMeshProUGUI text;


    [SerializeField] GameObject _angryEmote;
    private float _timeRemaining = 3;
    private bool _timerIsRunning;

    [SerializeField] AudioClip _pickup;
    [SerializeField] AudioClip _crunch;
    [SerializeField] AudioClip _clear;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        initialSpeed = GetComponent<Player>().moveSpeed;
        _ratIsAngry = false;
        //_angryEmote.SetActive(false);
        _timerIsRunning = false;
    }


    void FixedUpdate()
    {
        midSpeed = initialSpeed * 0.75f;
        slowSpeed = initialSpeed * 0.5f;
        if (GameManager.Instance.IsGamePlaying())
        {
            //Debug.Log("arg");
           
        }

        text.text = "Weight : " + carriedWeight + "/" + maxWeight;
        scoreText.text = "Score : " + score;
        ChangeSpeed();
        AngryEmote();
    }

    private void Update()
    {

        if (_timerIsRunning)
        {
            _angryEmote.SetActive(true);

            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Rat Is No Longer Angry");
                _timeRemaining = 3;
                _timerIsRunning = false;
                _ratIsAngry = false;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out FoodProperties food))
        {
          //  FoodSO food = collision.gameObject.GetComponent<FoodSO>();
            /////Weight check/////
            
            if (carriedWeight + food.foodSO.weight <= maxWeight)
            {
                carriedWeight += food.foodSO.weight;
                Debug.Log(carriedWeight);

                /////Item/////
                
                collision.gameObject.SetActive(false);
                score += food.foodSO.score;
                _audioSource.PlayOneShot(_pickup);

                /////Speed change/////

                //ChangeSpeed();
                if (collision.CompareTag("babyRat"))
                {
                    _ratIsAngry = true;
                }

            }
        }

        if (collision.GetComponent<BoostPill>())
        {
            _audioSource.PlayOneShot(_crunch);
        }

        /////Nest collision/////

        if (collision.GetComponent<NestProperties>())
        {
            Player.Instance.moveSpeed = initialSpeed;
            carriedWeight = 0;
            
            if(score > 0)
            {
                _audioSource.PlayOneShot(_clear);
                collision.GetComponent<NestProperties>().foodScore += score;
                score = 0;
            }
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<NestProperties>())
        {
            score = 0;
        }

        if (collision.CompareTag("babyRat"))
        {
            _ratIsAngry = true;
        }
    }

    public void ChangeSpeed()
    {
        if (carriedWeight >= maxWeight / 2)
        {
            if (carriedWeight == maxWeight)
            {
                Player.Instance.moveSpeed = slowSpeed;

            }
            else
            {
                Player.Instance.moveSpeed = midSpeed;     

            }
        }
        else
        {
            Player.Instance.moveSpeed = initialSpeed;
        }
    }

    public void AngryEmote()
    {
        if (_ratIsAngry == true)
        {
            _timerIsRunning = true;
        }
        if (_ratIsAngry == false)
        {
            _angryEmote.SetActive(false);
        }
    }
}
