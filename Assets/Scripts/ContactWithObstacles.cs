using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactWithObstacles : MonoBehaviour
{
    public Rigidbody characterRigidbody;
    public LayerMask movableObjectLayer;

    public Vector3 objectMovement;

    public bool isOnObstacle = false;

    GameObject troncoTocado;

    public static ContactWithObstacles Instance;

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

    void Update()
    {
        if (isOnObstacle == true)
        {
            SetObjectMovement(new Vector3(troncoTocado.transform.position.x, transform.position.y, transform.position.z));
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacles"))
        {
            isOnObstacle = true;
            troncoTocado = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacles"))
        {
            isOnObstacle = false;
        }
    }

    public void SetObjectMovement(Vector3 movement)
    {
        objectMovement = movement;
    }
}



