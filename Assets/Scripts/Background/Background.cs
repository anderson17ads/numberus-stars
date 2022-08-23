using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float speed;

    private MeshRenderer meshRenderer;

    private Vector2 offsetMaterial;

    private const string MAIN_TEX = "_MainTex";

    private void Start() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
        offsetMaterial = meshRenderer.material.GetTextureOffset(MAIN_TEX);
    }

    private void Update() 
    {
        offsetMaterial.y -= speed * Time.deltaTime;
        meshRenderer.material.SetTextureOffset(MAIN_TEX, offsetMaterial);
    }
}
