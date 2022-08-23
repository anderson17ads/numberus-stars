using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float timeInterval;

    private float timeCount;

    [Header("Shots")]
    [SerializeField]
    private List<GameObject> shotsPrefabs = new List<GameObject>();

    [Header("Guns")]
    [SerializeField]
    private Transform[] guns;

    private int gunCurrentIndex;
    
    private void Update()
    {
        timeCount += Time.deltaTime;

        onShot();
    }

    private void onShot()
    {
        if (timeCount < timeInterval) {
            return;
        }
        
        if (Input.GetButton("Fire1")) {
            Instantiate(shotsPrefabs[0], guns[gunCurrentIndex].position, Quaternion.identity);
            
            gunCurrentIndex = gunCurrentIndex == 1 ? 0 : 1;

            timeCount = 0f;
        }
    }
}