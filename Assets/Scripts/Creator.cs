using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public bool somethingInside = false;

    //creamos un singleton
    public static Creator Instance;

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
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("level"))
        {
            somethingInside = true;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("level"))
        {
            somethingInside = false;
            
        }
    }
}
