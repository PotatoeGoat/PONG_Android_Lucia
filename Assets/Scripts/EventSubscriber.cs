using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    public float rotationSpeed = 0.25f;

    GameObject chicken;
    public float duration = 0.1f;

    private void Awake()
    {
        chicken = this.gameObject;
    }

    private void Start()
    {
        //se suscribe al evento
        SwipeController.Instance.OnSwipeScreen += MoveTarget;
    }

    public void OnDisable()
    {
        //En caso de que se elimine el objeto que se suscribe, se elimina la suscripcion
        SwipeController.Instance.OnSwipeScreen -= MoveTarget;
    }

    void MoveTarget(Vector3 direction)
    {
        if (direction.x > 0)
        {
            MovementTarjet(direction/2);
            RotatePlayer(90f);

        }
        if (direction.x < 0)
        {
            MovementTarjet(direction/2);
            RotatePlayer(-90f);
        }
        if (direction.z > 0)
        {
            MovementTarjet(Vector3.zero);
            RotatePlayer(0f);
        }
        if (direction.z < 0)
        {
            MovementTarjet(Vector3.zero);
            RotatePlayer(-180f);
        }
    }

    void MovementTarjet(Vector3 direction)
    {
        //Debug.Log(direction);
        LeanTween.moveLocal(chicken, chicken.transform.position + direction + Vector3.up, duration / 2).setEase(LeanTweenType.easeOutCubic).setOnComplete(() =>
        {
            LeanTween.moveLocal(chicken, chicken.transform.position + direction - Vector3.up, duration / 2).setEase(LeanTweenType.easeOutCubic);

        });
    }

    void RotatePlayer(float angle)
    {
        //transform.eulerAngles = new Vector3(0f, angle, 0f);

        LeanTween.rotateLocal(chicken, new Vector3(0f, angle, 0f),rotationSpeed );
    }
}
