using UnityEngine;

public class ControladorFondoCamara : MonoBehaviour
{
    public Camera camara;
    public Transform[] fondos;
    public float margenError = 1.0f; 

    private float anchoSprite;
    private float anchoCamara;

    void Start()
    {
        if (fondos.Length == 0) return;

        SpriteRenderer sr = fondos[0].GetComponent<SpriteRenderer>();
        anchoSprite = sr.bounds.size.x;

        float altoCamara = camara.orthographicSize;
        anchoCamara = altoCamara * camara.aspect;
    }

    void Update()
    {
        foreach (var fondo in fondos)
        {
            // Izquierda -> Derecha (Añadimos - margenError)
            if (fondo.position.x + (anchoSprite / 2) < camara.transform.position.x - anchoCamara - margenError)
            {
                ReubicarFondo(fondo, true);
            }
            // Derecha -> Izquierda (Añadimos + margenError)
            else if (fondo.position.x - (anchoSprite / 2) > camara.transform.position.x + anchoCamara + margenError)
            {
                ReubicarFondo(fondo, false);
            }
        }
    }

    void ReubicarFondo(Transform fondoMover, bool moverAlFinalDerecho)
    {
        float valorExtremo = moverAlFinalDerecho ? -Mathf.Infinity : Mathf.Infinity;

        foreach (var f in fondos)
        {
            if (moverAlFinalDerecho)
            {
                if (f.position.x > valorExtremo) valorExtremo = f.position.x;
            }
            else
            {
                if (f.position.x < valorExtremo) valorExtremo = f.position.x;
            }
        }

        Vector3 nuevaPos = fondoMover.position;
        nuevaPos.x = valorExtremo + (moverAlFinalDerecho ? anchoSprite : -anchoSprite);
        fondoMover.position = nuevaPos;
    }
}