using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tramos2y4Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("destructor"))
        {
            PoolTramos2y4.Instance.ReturnTramoToPool(this.gameObject);
            DestructorBehaviour.Instance.tramoDestruido = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destructor"))
        {
            PoolTramos2y4.Instance.ReturnTramoToPool(this.gameObject);
            DestructorBehaviour.Instance.tramoDestruido = true;
        }
    }
}
