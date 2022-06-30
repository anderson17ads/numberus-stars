using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float timeToCreate;

    private float timeCount;

    [Header("Components")]
    [SerializeField]
    private GameObject enemyPrefab;

    private Vector2 viewportTop;

    private Vector2 viewportBottom;

    void Update()
    {
        onCreate();
        onViewportPosition();
    }

    private void onCreate()
    {
        timeCount += Time.deltaTime;

        if (timeCount < timeToCreate) {
            return;
        }
        
        Vector2 position = new Vector2(
            Random.Range(viewportBottom.x, viewportTop.x), 
            viewportTop.y
        );

        Instantiate(enemyPrefab, position, Quaternion.identity);

        timeCount = 0f;
    }

    private void onViewportPosition()
    {
        viewportTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        viewportBottom = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }
}
