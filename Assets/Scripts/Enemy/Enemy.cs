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

    [SerializeField]
    private float health;

    private Rigidbody2D rig;

    [Header("Components")]
    [SerializeField]
    private ParticleSystem explosionPrefab;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        speed = Random.Range(speedMin, speedMax);
    }

    private void Update() 
    {
        onDestroyWhenInvisible();
    }

    private void FixedUpdate() 
    {
        onMove();
    }

    private void onMove()
    {
        rig.velocity = new Vector2(0f, -speed);
    }

    public void handleHit()
    {
        health--;

        if (health <= 0f) {
            handleDestroy();
        }
    }

    public void handleDestroy(bool addScore = true, bool isExplosion = true)
    {
        if (addScore) {
            PlayerController.instance.score++;
        }

        if (isExplosion) {
            ParticleSystem explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
        }
        
        Destroy(gameObject);
    }

    private void onDestroyWhenInvisible()
    {
        Vector3 objectPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (objectPosition.y < 0f) {
            PlayerController.instance.healthCurrent--;
            handleDestroy(false, false);
        }
    }
}
