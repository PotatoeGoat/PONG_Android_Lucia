using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PoolTRoncos : MonoBehaviour
{
    public GameObject[] troncoPrefab;
    public int poolSize = 100;
    public Transform parentObject;

    private List<GameObject> troncoPool = new List<GameObject>();

    public static PoolTRoncos Instance;

    private void Awake()
    {
        //configurar singletone
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
        SetupPoolTroncos();
    }

    void SetupPoolTroncos()
    {
        //Inicializar la pool
        troncoPool = new List<GameObject>();
        

        // Instanciar y desactivar todas las balas al inicio
       for (int i = 0; i < poolSize; i++)
        {
            GameObject tronco = Instantiate(troncoPrefab[Random.Range(0, troncoPrefab.Length)]);
            tronco.SetActive(false);
            tronco.transform.SetParent(parentObject);
            troncoPool.Add(tronco);
        }
    }

    public GameObject GetTronco()
    {
        GameObject newTronco = null;

        if (troncoPool.Count == 0)
        {
            GameObject tronco = Instantiate(troncoPrefab[Random.Range(0, troncoPrefab.Length)]);
            tronco.SetActive(false);
            tronco.transform.SetParent(parentObject);
            troncoPool.Add(tronco);
            //Debug.LogWarning("No hay troncos disponibles en la piscina. Considera aumentar el tamaño de la piscina.");
            return null;
        }
        else
        {
            newTronco = troncoPool[Random.Range(0, troncoPool.Count)];
            newTronco.SetActive(true);
            troncoPool.Remove(newTronco);
        }

        return newTronco;
    }

    public void ReturnTroncoToPool(GameObject tronco)
    {
        tronco.SetActive(false);
        troncoPool.Add(tronco);
    }
}

