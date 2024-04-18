using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncosBehaviour : MonoBehaviour
{
    
    
    public float troncoSpeed = 5f;

    public float easySpeed = 1f;
    public float mediumSpeed = 2f;
    public float hardSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoTronco();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stop"))
        {
            
            DesactivacionTronco();
            Debug.Log("tronco desactivado");

        }

        if (other.CompareTag("easy"))
        {
            troncoSpeed = easySpeed;
        }

        if (other.CompareTag("medium"))
        {
            troncoSpeed = mediumSpeed;
        }

        if (other.CompareTag("hard"))
        {
            troncoSpeed = hardSpeed;
        }
    }


    void DesactivacionTronco()
    {
        this.gameObject.SetActive(false);
        PoolTRoncos.Instance.ReturnTroncoToPool(this.gameObject);
    }

    void MovimientoTronco()
    {

        Vector3 forwardMovement = transform.right * troncoSpeed * Time.deltaTime;
        transform.localPosition += forwardMovement;
    }
}
