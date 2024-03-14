using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador

    void Update()
    {
        // Verificamos si el jugador está asignado
        if (jugador != null)
        {
            // Igualamos la posición y rotación de la cámara a la del jugador
            transform.position = jugador.position;
            //transform.rotation = jugador.rotation;
        }

    }
}
