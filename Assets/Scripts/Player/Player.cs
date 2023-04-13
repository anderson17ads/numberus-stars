using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speedKeyboard;

    [SerializeField]
    private float speedMouse;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        onMoveKeyboard();
        onMoveMouse();
        onMoveTouch();
    }

    private void onMoveKeyboard()
    {
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0)) {
            Vector2 inputDirection = new Vector2(
                Input.GetAxisRaw("Horizontal"), 
                Input.GetAxisRaw("Vertical")
            );

            rig.MovePosition(rig.position + inputDirection * speedKeyboard * Time.fixedDeltaTime);
        }
    }

    private void onMoveMouse()
    {
        if ((Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0)) {
            rig.position = Vector2.Lerp(
                this.transform.position,
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                (speedMouse * Time.fixedDeltaTime)
            );
        }
    }

    private void onMoveTouch()
    {
        if (Input.touchCount > 0) {
            rig.position = Vector2.Lerp(
                this.transform.position,
                Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position),
                (speedMouse * Time.fixedDeltaTime)
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<Enemy>().handleDestroy(false);
            
            PlayerController.instance.healthCurrent--;
        }

        if (collision.CompareTag("ItemHealth")) {
            ItemHealth itemHealth = collision.GetComponent<ItemHealth>();
            
            PlayerController.instance.healthCurrent += itemHealth.health;
            
            itemHealth.handleDestroy();
        }
    }
}
