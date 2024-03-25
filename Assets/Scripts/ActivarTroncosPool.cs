using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarTroncosPool : MonoBehaviour
{
    public PoolTRoncos poolTRoncos;

    float timer = 0f;
    public float time = 2f;

    void Start()
    {
        time = Random.Range(2, 4);
        ActivarTronco();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            ActivarTronco();
            timer = 0f;
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
        }
    }
}
