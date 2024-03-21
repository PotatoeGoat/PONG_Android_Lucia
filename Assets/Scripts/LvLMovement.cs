using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvLMovement : MonoBehaviour
{
    public int carril = 0;

    public GameObject[] tramos;

    public GameObject nivel;
    public float duration = 0.1f;

    public EventSubscriber eventSubscriber;

    // Start is called before the first frame update
    void Start()
    {
        //se suscribe al evento
        SwipeController.Instance.OnSwipeScreen += LevelBehaviour;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelBehaviour(Vector3 direction)
    {
        Random.Range(0, tramos.Length);

        Instantiate(tramos[Random.Range(0, tramos.Length)], Vector3.back * carril, Quaternion.identity);
        if (direction.z > 0 && eventSubscriber.isOnLimit == true)
        {
            MovementTarjet(direction);
            carril++;
        }
        
        
    }

    void MovementTarjet(Vector3 direction)
    {
        //Debug.Log(direction);
        LeanTween.moveLocal(nivel, nivel.transform.position + direction, duration).setEase(LeanTweenType.easeOutCubic);
        
    }
}