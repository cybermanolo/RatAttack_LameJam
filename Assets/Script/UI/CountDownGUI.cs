using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountDownGUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;
   
    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
       
    }
    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStart())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
  
    private void Update()
    {
  
        countDownText.text = Mathf.Ceil(GameManager.Instance.GetCountdownToStartTimer()).ToString();
      
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}


