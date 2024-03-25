using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsBehaviour : MonoBehaviour
{
    public float carSpeed = 5f;

    Vector3 InitialPosition;



    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
        carSpeed = Random.Range(5, 7);
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
            Debug.Log("coche no desactivado");
            DesactivacionCoches();
            Debug.Log("coche desactivado");

        }
        
    }


    void DesactivacionCoches()
    {
        this.gameObject.SetActive(false);
        PoolCoches.InstanceCoche.ReturnCocheToPool(this.gameObject);
    }
}
