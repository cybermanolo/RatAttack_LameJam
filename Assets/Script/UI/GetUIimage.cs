using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetUIimage : MonoBehaviour
{
    private Sprite _image;
    [SerializeField] private Sprite _grey;
    [SerializeField] private Sprite _black;
    [SerializeField] private Sprite _white;

    // Start is called before the first frame update
    void Start()
    {
        //ChangeImg();
        _image = gameObject.GetComponent<Image>().sprite;
        _grey = gameObject.GetComponent<Image>().sprite;
        _black = gameObject.GetComponent<Image>().sprite;
        _white = gameObject.GetComponent<Image>().sprite;

    }

    //void ChangeImg()
    //{
    //    _image = gameObject.GetComponent<Image>().sprite;

    //}
}
