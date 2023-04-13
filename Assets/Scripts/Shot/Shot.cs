using UnityEngine;

public class Shot : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float speed;

    private Rigidbody2D rig;

    private bool isCollision;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
        rig.velocity = new Vector2(0f, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Enemy") && !isCollision) {
            isCollision = true;
            collision.GetComponent<Enemy>().handleHit();
            Destroy(gameObject);
        }
    }

    private void onDestroyWhenInvisible()
    {
        Vector3 objectPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (objectPosition.y > 1f) {
            Destroy(gameObject);
        }
    }
}
