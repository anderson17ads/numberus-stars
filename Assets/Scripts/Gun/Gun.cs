using System.Collections.Generic;
using UnityEngine;

enum GunTypes
{
    ALTERNATE,
    DOUBLE,
}

public class Gun : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    public float timeInterval;

    public float timeCount;

    [Header("Guns")]
    [SerializeField]
    private List<GameObject> guns = new List<GameObject>();

    public int gunCurrentIndex;

    public int gunCurrentType;

    public static Gun instance;

    private void Awake() 
    {
        instance = this;
    }

    private void Start()
    {
        gunCurrentIndex = 0;
    }

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

        guns[gunCurrentIndex].GetComponent<IGun>().onShot();
    }
}