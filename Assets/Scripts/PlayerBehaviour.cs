using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    float time = 1f;

    float timer = 0f;
    
    bool touchingWater = false;

    

    // Start is called before the first frame update
    void Start()
    {
        touchingWater = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touchingWater == true)
        {
            timer += Time.deltaTime;

            if (timer > time)
            {
                GameController.Instance.isDead = true;
                timer = 0f;
            }
        }

        
        /*RaycastHit hit;
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
            
            
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LimiteLateral"))
        {
            GameController.Instance.isDead = true;
        }

        if (other.CompareTag("water"))
        {
            touchingWater = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("danger"))
        {
            GameController.Instance.isDead = true;
        }
        if (collision.gameObject.CompareTag("troncos"))
        {
            EventSubscriber.Instance.youCanJump = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
