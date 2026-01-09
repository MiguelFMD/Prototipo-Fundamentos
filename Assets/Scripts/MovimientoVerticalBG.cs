using UnityEngine;

public class MovimientoVerticalBG : MonoBehaviour
{
    [SerializeField] private Vector2 scrollSpeed = new Vector2(0.1f, 0.1f);
    private Material bgMaterial;

    void Start()
    {
        bgMaterial = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        bgMaterial.mainTextureOffset += scrollSpeed * Time.deltaTime;
    }
}