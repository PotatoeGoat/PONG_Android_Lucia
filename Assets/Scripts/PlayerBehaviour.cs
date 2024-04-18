using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    Transform objectParent;

    public Transform forward;

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            if (hit.collider.CompareTag("troncos"))
            {
                EventSubscriber.Instance.youCanJump = true;
            }
            else if (hit.collider.CompareTag("water"))
            {
                EventSubscriber.Instance.youCanJump = false;
            }
            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LimiteLateral"))
        {
            GameController.Instance.isDead = true;
        }

        if (other.CompareTag("water"))
        {
            GameController.Instance.isDead = true;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("danger"))
        {
            GameController.Instance.isDead = true;
        }
        /*if (collision.gameObject.CompareTag("floor"))
        {
            transform.parent = null;
        }*/
        if (collision.gameObject.CompareTag("troncos"))
        {
            EventSubscriber.Instance.youCanJump = true;
            objectParent = collision.gameObject.transform;
            transform.parent = objectParent;


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("troncos"))
        {
            
            transform.parent = null;


        }
    }

}
