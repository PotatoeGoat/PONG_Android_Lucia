using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Pool1x1 : MonoBehaviour
{
    public GameObject[] tramoPrefab;
    public int poolSize = 12;

    private List<GameObject> tramoPool = new List<GameObject>();

    public static Pool1x1 Instance1x1;

    private void Awake()
    {
        // Configurar singleton
        if (Instance1x1 == null)
        {
            Instance1x1 = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        SetupPool1x1();
    }

    void SetupPool1x1()
    {
        // Inicializar la pool
        tramoPool = new List<GameObject>();

        // Instanciar y desactivar todos los tramos al inicio
        for (int i = 0; i < poolSize; i++)
        {
            GameObject tramo = Instantiate(tramoPrefab[Random.Range(0, tramoPrefab.Length)]);
            tramo.SetActive(false);
            tramoPool.Add(tramo);
        }
    }

    public GameObject GetTramo()
    {
        GameObject newTramo = null;

        if (tramoPool.Count == 0)
        {
            GameObject tramo = Instantiate(tramoPrefab[Random.Range(0, tramoPrefab.Length)]);
            tramo.SetActive(false);
            tramoPool.Add(tramo);
            // Debug.LogWarning("No hay tramos disponibles en la piscina. Considera aumentar el tamaño de la piscina.");
            return null;
        }
        else
        {
            newTramo = tramoPool[Random.Range(0, tramoPool.Count)];
            newTramo.SetActive(true);
            tramoPool.Remove(newTramo);
        }

        return newTramo;
    }

    public void ReturnTramoToPool(GameObject tramo)
    {
        tramoPool.Add(tramo);
        tramo.SetActive(false);
    }
}

