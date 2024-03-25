using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCochesPool : MonoBehaviour
{
    public PoolCoches poolCoches;

    float timer = 0f;
    public float time = 2f;

    void Start()
    {
        time = Random.Range(2, 4);
        ActivarCoche();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            ActivarCoche();
            timer = 0f;
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
}
