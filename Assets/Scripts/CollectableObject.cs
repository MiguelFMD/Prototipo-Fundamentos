using UnityEngine;
using System;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    [SerializeField, Range(0f, 1f)] private float volume = 0.5f;
    public static event Action OnObjectCollected;
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
            }
            OnObjectCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}