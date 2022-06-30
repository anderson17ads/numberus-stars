using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rig;

    private Vector2 inputDirection;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        onInput();
    }

    private void FixedUpdate() 
    {
        onMove();
    }

    private void onInput()
    {
        inputDirection = new Vector2(
            Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical")
        );
    }

    private void onMove()
    {
        rig.MovePosition(rig.position + inputDirection * speed * Time.fixedDeltaTime);
    }
}
