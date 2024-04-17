using UnityEngine;

public class GeneradorTramos : MonoBehaviour
{
    public Transform generationPoint; // Punto de generación de los tramos
    //public GameObject trigger; // El objeto trigger que detiene la generación de tramos
    public int cantidadTramosAGenerar = 24; // Cantidad de tramos a generar cuando se activa el trigger

    //bool somethingInside = false;

    private void Start()
    {
       
        for (int i = 0; i < cantidadTramosAGenerar; i++)
        {
            GenerarTramo();
            
        }
    }

    private void Update()
    {
        if(DestructorBehaviour.Instance.tramoDestruido == true)
        {
            GenerarTramo();
            
        }
    }

    public void GenerarTramo()
    {
        // Obtener un tramo de la pool
        GameObject tramo = PoolTramos2y4.Instance.GetTramo();

        if (tramo != null)
        {
            // Obtener el tamaño real del tramo
            Collider collider = tramo.GetComponent<Collider>();
            if (collider != null)
            {
                // Calcular el offset como la mitad del tamaño real en el eje Z
                Vector3 offset = new Vector3(0f, 0f, collider.bounds.size.z/2f);

                // Posicionar el tramo en el punto de generación con el offset calculado
                tramo.transform.position = generationPoint.position + offset;

                // Activar el tramo
                tramo.SetActive(true);

                // Actualizar la posición del punto de generación para el siguiente tramo
                generationPoint.position += offset * 2f;
                DestructorBehaviour.Instance.tramoDestruido = false;
            }
            else
            {
                Debug.LogWarning("El tramo no tiene un Collider adjunto.");
            }

            
        }
    }
}



