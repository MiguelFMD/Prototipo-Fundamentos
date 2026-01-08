using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;
public class CameraZoomOut : MonoBehaviour
{
    private CinemachineCamera CameraFar;
    bool far = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CameraFar = GetComponent<CinemachineCamera>();
        CameraFar.Priority = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            if (far)
            {
                far = false;
                CameraFar.Priority = -1;
            }
            else
            {
                far = true;
                CameraFar.Priority = 2;
            }
        }
    }

}
