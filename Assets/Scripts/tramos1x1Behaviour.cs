using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tramos1x1Behaviour : MonoBehaviour
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
            Pool1x1.Instance1x1.ReturnTramoToPool(this.gameObject);
            DestructorBehaviour.Instance.tramoDestruido = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destructor"))
        {
            Pool1x1.Instance1x1.ReturnTramoToPool(this.gameObject);
            DestructorBehaviour.Instance.tramoDestruido = true;
        }
    }
}
