using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvLMovement : MonoBehaviour
{
    GameObject nivel;
    public float duration = 0.1f;

    

    // Start is called before the first frame update
    void Start()
    {
        //se suscribe al evento
        SwipeController.Instance.OnSwipeScreen += LevelBehaviour;

        nivel = this.gameObject;
    }

    private void OnDisable()
    {
        SwipeController.Instance.OnSwipeScreen -= LevelBehaviour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelBehaviour(Vector3 direction)
    {
        if (direction.z > 0 && EventSubscriber.Instance.isOnLimit == true && EventSubscriber.Instance.youCanJump == true)
        {
            MovementTarjet(-direction);
        }
    }

    void MovementTarjet(Vector3 direction)
    {
        //Debug.Log(direction);
        LeanTween.moveLocal(nivel, nivel.transform.position + direction, duration).setEase(LeanTweenType.easeOutCubic);
        
    }
}
