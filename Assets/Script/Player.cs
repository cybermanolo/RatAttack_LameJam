using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float moveSpeed = 7f;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 inputVector;

    public static Player Instance { get; private set; }
    // Update is called once per frame

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
      
        inputVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z))
        {
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
        }

        inputVector = inputVector.normalized;
        transform.position += inputVector * moveSpeed * Time.deltaTime;

        if (inputVector != Vector3.zero)
        {
            float angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg - 180f;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        animator.SetFloat("Speed", inputVector.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}
