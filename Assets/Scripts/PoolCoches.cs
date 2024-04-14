using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PoolCoches : MonoBehaviour
{
    public GameObject[] cochePrefab;
    public int poolSize = 100;
    public Transform parentObject;

    private List<GameObject> cochePool = new List<GameObject>();

    public static PoolCoches InstanceCoche;

    private void Awake()
    {
        //configurar singletone
        if (InstanceCoche == null)
        {
            InstanceCoche = this;
        }
        else
        {
            Destroy(this.gameObject);

        }

    }

    private void Start()
    {
        SetupPoolCoches();
    }

    void SetupPoolCoches()
    {
        //Inicializar la pool
        cochePool = new List<GameObject>();


        // Instanciar y desactivar todas las balas al inicio
        for (int i = 0; i < poolSize; i++)
        {
            GameObject coche = Instantiate(cochePrefab[Random.Range(0, cochePrefab.Length)]);
            coche.SetActive(false);
            coche.transform.SetParent(parentObject);
            cochePool.Add(coche);
        }
    }

    public GameObject GetCoche()
    {
        GameObject newCoche = null;

        if (cochePool.Count == 0)
        {
            GameObject coche = Instantiate(cochePrefab[Random.Range(0, cochePrefab.Length)]);
            coche.SetActive(false);
            cochePool.Add(coche);
            //Debug.LogWarning("No hay coches disponibles en la piscina. Considera aumentar el tamaño de la piscina.");
            return null;
        }
        else
        {
            newCoche = cochePool[Random.Range(0, cochePool.Count)];
            newCoche.SetActive(true);
            cochePool.Remove(newCoche);
        }

        return newCoche;
    }

    public void ReturnCocheToPool(GameObject coche)
    {
        cochePool.Add(coche);
        coche.SetActive(false);
        
    }
}

