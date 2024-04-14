using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PoolTramos2y4 : MonoBehaviour
{
    public GameObject[] tramos2y4Prefab;
    public int poolSize = 100;

    private List<GameObject> tramos2y4Pool = new List<GameObject>();

    public static PoolTramos2y4 Instance;

    private void Awake()
    {
        // Configurar singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        SetupPoolTramos2y4();
    }

    void SetupPoolTramos2y4()
    {
        // Inicializar la pool
        tramos2y4Pool = new List<GameObject>();

        // Instanciar y desactivar los objetos al inicio
        for (int i = 0; i < poolSize; i++)
        {
            GameObject tramo = Instantiate(tramos2y4Prefab[Random.Range(0, tramos2y4Prefab.Length)]);
            tramo.SetActive(false);
            tramos2y4Pool.Add(tramo);
        }
    }

    public GameObject GetTramo()
    {
        GameObject newTramo = null;

        if (tramos2y4Pool.Count == 0)
        {
            GameObject tramo = Instantiate(tramos2y4Prefab[Random.Range(0, tramos2y4Prefab.Length)]);
            tramo.SetActive(false);
            tramos2y4Pool.Add(tramo);
            //Debug.LogWarning("No hay tramos disponibles en la piscina. Considera aumentar el tamaño de la piscina.");
            return null;
        }
        else
        {
            newTramo = tramos2y4Pool[Random.Range(0, tramos2y4Pool.Count)];
            newTramo.SetActive(true);
            tramos2y4Pool.Remove(newTramo);
        }

        return newTramo;
    }

    public void ReturnTramoToPool(GameObject tramo)
    {
        tramos2y4Pool.Add(tramo);
        tramo.SetActive(false);
    }
}

