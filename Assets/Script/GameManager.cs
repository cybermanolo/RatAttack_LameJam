using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event EventHandler OnStateChanged;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject gameStartCountDownUI;
    [SerializeField] private GameObject _minimap;

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }
    private State state;

    private float countdownToStartTimer = 3f ;
    private float gamePlayingTimer = 300f;
    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    private void Start()
    {
        _minimap.SetActive(false);
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                    gameStartCountDownUI.gameObject.SetActive(false);
                    playerUI.gameObject.SetActive(true);
                    _minimap.SetActive(true);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if(gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
                
        }
        //Debug.Log(state);
    }

    public void StartGame()
    {
        
        gameStartCountDownUI.gameObject.SetActive(true);
        countdownToStartTimer = 3f;
        state = State.CountdownToStart;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
       // Debug.Log("C ici sa ce passe waaaaaa" + state);
       // OnStateChanged?.Invoke(this, EventArgs.Empty);
       return;
    }
    
    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public bool IsCountdownToStart()
    {
        return state == State.CountdownToStart;
    }
    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;
    }
}
