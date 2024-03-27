using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCochesPool : MonoBehaviour
{
    public PoolCoches poolCoches;

    public bool cocheDentro = false;

    void Start()
    {
        ActivarCoche();
    }

    private void Update()
    {
        if (cocheDentro == false)
        {
            ActivarCoche();
            cocheDentro = true;
        }

    }

    private void ActivarCoche()
    {
        GameObject coche = poolCoches.GetCoche();
        if (coche != null)
        {
            // Colocar el coche en la posición deseada y activarlo
            coche.transform.position = transform.position;
            coche.transform.rotation = transform.rotation;
            coche.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacles"))
        {
            cocheDentro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("obstacles"))
        {
            cocheDentro = false;
        }
    }
}
