using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class StartGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button startButton;
    // Start is called before the first frame update
    private bool grow = true;
    private void Awake()
    {
        startButton.onClick.AddListener(StartGameButton);
    }

    private void Update()
    {
        if (grow)
        {
            text.fontSize += Time.deltaTime * 10;
            if ( text.fontSize >= 70)
                grow = false;
        }
        else
        {
            text.fontSize -= Time.deltaTime * 10;
            if (text.fontSize <= 50)
                grow = true;
        }
    }

    public void StartGameButton()
    {
        GameManager.Instance.StartGame();
        this.gameObject.SetActive(false);
    }
}
