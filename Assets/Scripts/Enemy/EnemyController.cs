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

    private Vector2 viewportTop;

    private Vector2 viewportBottom;

    [Header("Components")]
    [SerializeField]
    private GameObject[] enemiesPrefab;

    void Update()
    {
        timeCount += Time.deltaTime;
        
        onCreate();
        onViewportPosition();
    }

    private void onCreate()
    {
        if (timeCount < timeInterval) {
            return;
        }
        
        Vector2 position = new Vector2(
            Random.Range(viewportBottom.x, viewportTop.x), 
            viewportTop.y
        );

        indexEnemy = Random.Range(0, enemiesPrefab.Length);

        Instantiate(enemiesPrefab[indexEnemy], position, Quaternion.identity);

        timeCount = 0f;
    }

    private void onViewportPosition()
    {
        viewportTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        viewportBottom = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }
}
