using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            // Aquí tu lógica (puntos, inventario, sonido, etc.)
            
            Destroy(gameObject);
        }
    }
}