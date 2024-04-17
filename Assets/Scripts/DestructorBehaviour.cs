using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorBehaviour : MonoBehaviour
{
    public bool tramoDestruido = false;

    //creamos un singleton
    public static DestructorBehaviour Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("danger"))
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("troncos"))
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("level"))
        {
            tramoDestruido = true;
        }

        tramoDestruido = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("level"))
        {
            tramoDestruido = true;
        }

        tramoDestruido = true;
    }
}
