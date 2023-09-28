using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabiesScore : MonoBehaviour
{
    [SerializeField] private Image _grey;
    [SerializeField] private Image _black;
    [SerializeField] private Image _white;
    [SerializeField] private Image _brown;
    [SerializeField] private BabyRatAI[] _babyRatAIArray;
    // Update is called once per frame

    private void Start()
    {
        foreach (var babyrat in _babyRatAIArray)
        {
            
        
            babyrat.OnBabyRatDeath += BabyRatAI_OnBabyRatDeath;
        }
    }
    
    private void BabyRatAI_OnBabyRatDeath(object sender, BabyRatAI.WichRat e)
    {
        switch (e.rat)
        {
            case 3:
                Debug.Log("mort au rat 3");
                _grey.enabled = false;
                break;
            case 2:
                Debug.Log("mort au rat 2");
                _black.enabled = false;
                break;
            case 1:
                Debug.Log("mort au rat 1");
                _brown.enabled = false;
                break;
            case 0:
                Debug.Log("mort au rat 0");
                _white.enabled = false;
                break;
        }
    }
}
