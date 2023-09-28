using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FoodScore : MonoBehaviour
{
    public TextMeshProUGUI _score02;

    // Update is called once per frame
    void Update()
    {
        _score02.text = "Food = " + NestProperties.Nest.finalScore;
    }
}
