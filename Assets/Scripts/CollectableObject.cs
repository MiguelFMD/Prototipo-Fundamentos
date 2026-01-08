using UnityEngine;
using System;

public class CollectableObject : MonoBehaviour
{
    public static event Action OnObjectCollected;
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            OnObjectCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}