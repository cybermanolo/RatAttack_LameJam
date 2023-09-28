using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerGameOver : MonoBehaviour
{

    [SerializeField] private float _timeRemaining = 300;
    private bool _timerIsRunning;
    public Slider _slider;
    public GameObject _warningScreen;
    public GameObject _gameOver;
    [SerializeField] AudioClip _alarm;
    [SerializeField] AudioSource _audioSource;
    public GameObject _restartButton;
    public TextMeshProUGUI _score;

    public static TimerGameOver Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _timerIsRunning = true;

        _slider = GetComponent<Slider>();

        _warningScreen.SetActive(false);
        _gameOver.SetActive(false);
        _restartButton.SetActive(false);

        

        //_audioSource.Stop();

        //StartCoroutine(LoopAudio());
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _timeRemaining;
        if (GameManager.Instance.IsGamePlaying())
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;

                if (_timeRemaining < 30)
                {
                    //Debug.Log("Time is < 30");

                    _warningScreen.SetActive(true);

                    //_audioSource.Stop();
                    _audioSource.Play();
                }
            }

            else
            {                
                Debug.Log("Time has stopped");
                GameOver();
                //_audioSource.Stop();


            }
        }
    }

    public void GameOver()
    {
        _warningScreen.SetActive(true);
       // _timeRemaining = 0;
        _timerIsRunning = false;
        _gameOver.SetActive(true);

        NestProperties.Nest.FinalScore();
        _score.text = "Score = " + NestProperties.Nest.finalScore;
        _restartButton.SetActive(true);
    }

    //IEnumerator LoopAudio()
    //{
    //    //_audioSource = GetComponent<AudioSource>();
    //    float length = _audioSource.clip.length;

    //    while (true)
    //    {
    //        _audioSource.Play();
    //        yield return new WaitForSeconds(length);
    //    }
    //}
}
