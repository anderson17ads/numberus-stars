using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float speedMin;

    [SerializeField]
    private float speedMax;

    private float speed;

    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        speed = Random.Range(speedMin, speedMax);
    }

    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }

    private void FixedUpdate() 
    {
        onMove();
    }

    private void onMove()
    {
        rig.velocity = new Vector2(0f, -speed);
    }
}
