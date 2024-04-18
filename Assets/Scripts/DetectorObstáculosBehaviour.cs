using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorObstáculosBehaviour : MonoBehaviour
{
    public Transform player;

    

    public Vector3 offset;

    public int whereYouCanJump = 0; //cambiar segun direccion del obastaculo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacles"))
        {
            if (whereYouCanJump == 1)
            {
                EventSubscriber.Instance.youCanJumpForward = false;
            }
            else if (whereYouCanJump == 2)
            {
                EventSubscriber.Instance.youCanJumpRight = false;
            }
            else if (whereYouCanJump == 3)
            {
                EventSubscriber.Instance.youCanJumpBehind = false;
            }
            else if (whereYouCanJump == 4)
            {
                EventSubscriber.Instance.youCanJumpLeft = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("obstacles"))
        {
            if (whereYouCanJump == 1)
            {
                EventSubscriber.Instance.youCanJumpForward = true;
            }
            else if (whereYouCanJump == 2)
            {
                EventSubscriber.Instance.youCanJumpRight = true;
            }
            else if (whereYouCanJump == 3)
            {
                EventSubscriber.Instance.youCanJumpBehind = true;
            }
            else if (whereYouCanJump == 4)
            {
                EventSubscriber.Instance.youCanJumpLeft = true;
            }
        }
    }
}
