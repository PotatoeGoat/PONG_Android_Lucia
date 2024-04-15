using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LimiteLateral"))
        {
            GameController.Instance.RestartGame();
        }

        if (other.CompareTag("water"))
        {
            GameController.Instance.RestartGame();
        }
    }
}
