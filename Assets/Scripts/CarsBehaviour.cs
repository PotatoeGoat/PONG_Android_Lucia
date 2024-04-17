using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsBehaviour : MonoBehaviour
{
    public float carSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
        //carSpeed = Random.Range(5, 7);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardMovement = transform.forward * carSpeed * Time.deltaTime;
        transform.localPosition += forwardMovement;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stop"))
        {
            
            DesactivacionCoches();
            //Debug.Log("coche desactivado");

        }

        if (other.CompareTag("easy"))
        {
            carSpeed = 2f;
        }

        if (other.CompareTag("medium"))
        {
            carSpeed = 3f;
        }

        if (other.CompareTag("hard"))
        {
            carSpeed = 5f;
        }

    }


    void DesactivacionCoches()
    {
        this.gameObject.SetActive(false);
        PoolCoches.InstanceCoche.ReturnCocheToPool(this.gameObject);
    }
}
