using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    

    GameObject cube;
    public float duration = 0.1f;

    private void Awake()
    {
        cube = this.gameObject;
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
        Debug.Log(direction);
        LeanTween.moveLocal(cube, cube.transform.position + direction / 2 + Vector3.up, duration / 2).setEase(LeanTweenType.easeOutCubic).setOnComplete(() =>
        {
            LeanTween.moveLocal(cube, cube.transform.position + direction / 2 - Vector3.up, duration / 2).setEase(LeanTweenType.easeOutCubic);

        });

    }
}
