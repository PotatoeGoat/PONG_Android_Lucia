using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
   

    private void Start()
    {
        
    }
    void Update()
    {
        // Verificamos si el jugador está asignado
        if (jugador != null)
        {
            // Igualamos la posición de la cámara a la del jugador
            //El Vector.Lerp es para hacer la transicion de manera suave, desde una posicion a, a una posicion b, en un determinado tiempo
            Vector3 targetPosition = new Vector3(jugador.position.x, 0f, 0f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);

        }

    }
}
