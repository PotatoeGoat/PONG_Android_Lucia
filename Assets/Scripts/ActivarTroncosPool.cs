using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarTroncosPool : MonoBehaviour
{
    public PoolTRoncos poolTRoncos;

    


    public bool troncoDentro = false;

    void Start()
    {
        
        //ActivarTronco();
    }

    private void Update()
    {
      

        if (troncoDentro == false)
        {
            ActivarTronco();
            
        }
    }

    private void ActivarTronco()
    {
        GameObject tronco = poolTRoncos.GetTronco();
        if (tronco != null)
        {
            // Colocar el tronco en la posición deseada y activarlo
            tronco.transform.position = transform.position;
            tronco.transform.rotation = transform.rotation;
            tronco.SetActive(true);
            troncoDentro = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("troncos"))
        {
            troncoDentro = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("troncos"))
        {
            troncoDentro = false;
            
        }

    }

   
}
