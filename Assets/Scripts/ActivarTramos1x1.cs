using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarTramosInicio : MonoBehaviour
{
    public Pool1x1 poolTramos1x1;
    public int cantidadTramosActivar = 12;
    

    public Vector3 offset = new Vector3(0f,0f,0.5f);

    void Start()
    {
        

        for (int i = 0; i < cantidadTramosActivar; i++)
        {
            GameObject tramo = poolTramos1x1.GetTramo();
            if (tramo != null)
            {
                tramo.transform.position = transform.position + offset *i ;
                tramo.SetActive(true);
            }
        }
    }
}

