using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    private TrailRenderer _trailRenderer;
    //public Rigidbody2D _rigidBody;

    public Vector2 _movement;


    // Start is called before the first frame update
    void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if(Player.Instance.inputVector == Vector3.zero)
        {
            _trailRenderer.time += 0.5f;
        }
        else
        {
            _trailRenderer.time = 0.25f;
        }
       // _trailRenderer.time = 0.2f;
    }
}
