using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float timeInterval;

    private float timeCount;

    private int indexEnemy;

    [Header("Components")]
    [SerializeField]
    private GameObject[] enemiesPrefab;

    void Update()
    {
        timeCount += Time.deltaTime;
        
        onCreate();
    }

    private void onCreate()
    {
        if (timeCount < timeInterval) {
            return;
        }

        // Viewport Positions
        Vector2 viewportTop = Camera.main.ViewportToWorldPoint(Vector2.one);
        Vector2 viewportBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);

        // Position Current
        float positionCurrent = Random.Range(viewportBottom.x, viewportTop.x);
        
        // Enemy Current
        int indexEnemy = Random.Range(0, enemiesPrefab.Length);
        GameObject enemyCurrent = enemiesPrefab[indexEnemy];

        // Sprite Size
        SpriteRenderer spriteRenderer = enemyCurrent.GetComponent<SpriteRenderer>();
        Vector3 spriteSize = spriteRenderer.bounds.size;

        float spriteSizeWidthHalf = spriteSize.x / 2f;

        // Viewport Points Horizontal
        float viewportLeftPoint = positionCurrent - spriteSizeWidthHalf;
        float viewportRigthPoint = positionCurrent + spriteSizeWidthHalf;

        if (viewportLeftPoint < viewportBottom.x) {
            positionCurrent = viewportBottom.x + spriteSizeWidthHalf;
        }

        if (viewportRigthPoint > viewportTop.x) {
            positionCurrent = viewportTop.x - spriteSizeWidthHalf;
        }
        
        Vector2 position = new Vector2(
            positionCurrent, 
            viewportTop.y
        );

        Instantiate(enemyCurrent, position, Quaternion.identity);

        timeCount = 0f;
    }
}
