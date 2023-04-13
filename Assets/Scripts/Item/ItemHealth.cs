using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float _health;

    public float health
    {
        get { return _health; }
    }

    public void handleDestroy()
    {
        Destroy(gameObject);
    }
}
