using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRatAI : MonoBehaviour
{
    public float _speedMove;
    public int rat;
    [SerializeField] private GameObject nestBaby;
    private SpriteRenderer sprite;
    private TrailRenderer tail;
    public event EventHandler<WichRat> OnBabyRatDeath;
    public class WichRat : EventArgs
    {
        public int rat;
    }
    
    //public float _waitTime;
    //float raycastDistance= 1f;
    [SerializeField] private int _currentWaypointIndex;
    //bool _once;
    [SerializeField] Transform _nest;
    [SerializeField] Transform[] _waypoints;

    private bool isMoving = true;

    [SerializeField] AudioClip _death;
    [SerializeField] AudioSource _audioSource;



    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        tail = GetComponentInChildren<TrailRenderer>();
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, _speedMove * Time.deltaTime);
        }
        
        
    }


   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Waypoint") && _waypoints[_currentWaypointIndex] == other.transform)
        {

            if(_currentWaypointIndex < _waypoints.Length - 1)
            {
                _currentWaypointIndex++;
            }
            
        }
        else if(other.CompareTag("Mortauxrat"))
        {
            Destroy(gameObject);
            NestProperties.Nest.nbBabies -= 1;
            _audioSource.PlayOneShot(_death);
            OnBabyRatDeath?.Invoke(this,new WichRat{rat = rat});
        }

        if (other.CompareTag("Player"))
        {
            if (_currentWaypointIndex > 0)
            {
                _currentWaypointIndex--;
            }
            
        }

        if (other.CompareTag("Nest"))
        {
            isMoving = false;
            transform.position = other.transform.position;
            _currentWaypointIndex = 0;

            sprite.enabled = false;
            tail.enabled = false;

            nestBaby.SetActive(true);

            StartCoroutine(Countdown(UnityEngine.Random.Range(30, 50)));
        }

    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        isMoving = true;

        sprite.enabled = true;
        tail.enabled = true;

        nestBaby.SetActive(false);

        _currentWaypointIndex = 1;
    }
}
