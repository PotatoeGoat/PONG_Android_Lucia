using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncosBehaviour : MonoBehaviour
{
    public float troncoSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
        //troncoSpeed = Random.Range(2, 6);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardMovement = transform.up * troncoSpeed * Time.deltaTime;
        transform.localPosition += forwardMovement;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stop"))
        {

            DesactivacionCoches();
            Debug.Log("tronco desactivado");

        }

        if (other.CompareTag("easy"))
        {
            troncoSpeed = 2f;
        }

        if (other.CompareTag("medium"))
        {
            troncoSpeed = 3f;
        }

        if (other.CompareTag("hard"))
        {
            troncoSpeed = 5f;
        }
    }


    void DesactivacionCoches()
    {
        this.gameObject.SetActive(false);
        PoolTRoncos.Instance.ReturnTroncoToPool(this.gameObject);
    }
}
