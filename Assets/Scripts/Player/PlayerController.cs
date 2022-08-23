using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Score")]
    [SerializeField]
    private Text scoreText;
    
    private int _score;

    [Header("Health")]
    [SerializeField]
    private Image healthBar;

    [SerializeField]
    private float _healthTotal;

    private float _healthCurrent;

    private SpriteRenderer spriteRenderer;
    
    public int score
    {
        get { return _score; }
        set { _score = value; }
    }

    public float healthCurrent
    {
        get { return _healthCurrent; }
        set { _healthCurrent = value; }
    }

    public static PlayerController instance;

    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        _healthCurrent = _healthTotal;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        // Score
        scoreText.text = score.ToString();
        
        // Health
        healthBar.fillAmount = _healthCurrent / _healthTotal;

        if (_healthCurrent <= 0) {
            GameController.instance.gameOver();
        }

        // Limit Player in viewport
        handleLimitPlayerInViewport();
    }

    private void handleLimitPlayerInViewport()
    {
        // Viewport Positions
        Vector2 viewportTop = Camera.main.ViewportToWorldPoint(Vector2.one);
        Vector2 viewportBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);

        // Sprite Size
        Vector3 spriteSize = spriteRenderer.bounds.size;
        
        float spriteSizeWidthHalf = spriteSize.x / 2f;
        float spriteSizeHeigthHalf = spriteSize.y / 2f;

        // Viewport Points Horizontal
        float viewportLeftPoint = transform.position.x - spriteSizeWidthHalf;
        float viewportRigthPoint = transform.position.x + spriteSizeWidthHalf;
        
        // Viewport Points Vertical
        float viewportTopPoint = transform.position.y + spriteSizeHeigthHalf;
        float viewportBottomPoint = transform.position.y - spriteSizeHeigthHalf;

        // Limiting Player in Viewport Left Side
        if (viewportLeftPoint < viewportBottom.x) {
            transform.position = new Vector2(viewportBottom.x + spriteSizeWidthHalf, transform.position.y);
        }
        
        // Limiting Player in Viewport Rigth Side
        if (viewportRigthPoint > viewportTop.x) {
            transform.position = new Vector2(viewportTop.x - spriteSizeWidthHalf, transform.position.y);
        }

        // Limiting Player in Viewport Top
        if (viewportTopPoint > viewportTop.y) {
            transform.position = new Vector2(transform.position.x, viewportTop.y - spriteSizeHeigthHalf);
        }

        // Limiting Player in Viewport Bottom
        if (viewportBottomPoint < viewportBottom.y) {
            transform.position = new Vector2(transform.position.x, viewportBottom.y + spriteSizeHeigthHalf);
        }
    }
}
