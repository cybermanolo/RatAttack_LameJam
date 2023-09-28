using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private Button startButton;
    // Start is called before the first frame update
    private void Awake()
    {
        startButton.onClick.AddListener(RestartGameButton);
    }
    public void RestartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
