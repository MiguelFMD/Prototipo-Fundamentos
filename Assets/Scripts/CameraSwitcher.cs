using UnityEngine;

public class CameraZoneSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject mainCameraObject;
    [SerializeField] private GameObject eventCameraObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eventCameraObject.SetActive(true);
            mainCameraObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainCameraObject.SetActive(true);
            eventCameraObject.SetActive(false);
        }
    }
}