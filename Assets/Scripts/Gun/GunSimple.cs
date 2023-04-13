using System.Collections.Generic;
using UnityEngine;

public class GunSimple : MonoBehaviour, IGun
{
    [Header("Shots")]
    [SerializeField]
    private List<GameObject> shotsPrefabs = new List<GameObject>();

    [Header("GunItens")]
    [SerializeField]
    private Transform[] gunItens;

    protected int gunItemCurrentIndex;

    public void onShot()
    {
        if (Input.GetButton("Fire1")) {
            if (Gun.instance.gunCurrentType == (int) GunTypes.ALTERNATE) {
                shotAlternate();
            }

            if (Gun.instance.gunCurrentType == (int) GunTypes.DOUBLE) {
                shotDouble();
            }

            Gun.instance.timeCount = 0f;
        }
    }

    private void shotAlternate()
    {
        Instantiate(shotsPrefabs[0], gunItens[gunItemCurrentIndex].position, Quaternion.identity);

        gunItemCurrentIndex = gunItemCurrentIndex == 1 ? 0 : 1;
    }

    private void shotDouble()
    {
        Instantiate(shotsPrefabs[0], gunItens[0].position, Quaternion.identity);
        Instantiate(shotsPrefabs[0], gunItens[1].position, Quaternion.identity);
    }
}
