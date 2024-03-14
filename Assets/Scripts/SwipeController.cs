using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipeController : MonoBehaviour
{
    Vector3 clickInicial;
    Vector3 alsoltarclick;

    [SerializeField] GameObject cube;

    public float offset = 100;

    public float duration = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            clickInicial = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            alsoltarclick = Input.mousePosition;
            Vector3 diferencia = alsoltarclick - clickInicial;
            Debug.Log(diferencia);

            if (diferencia.x < -offset)
            {
                Debug.Log("Movimiento a izquierda");
                MoveTarget(-cube.GetComponent<Transform>().right);
            }

            if (diferencia.x > offset)
            {
                Debug.Log("Movimiento a derecha");
                MoveTarget(cube.GetComponent<Transform>().right);
            }

            if (diferencia.y < -offset)
            {
                Debug.Log("Movimiento a abajo");
                MoveTarget(-cube.GetComponent<Transform>().forward);
            }

            if (diferencia.y > offset)
            {
                Debug.Log("Movimiento a arriba");
                MoveTarget(cube.GetComponent<Transform>().forward);
            }

            //Debug.Log(diferencia);
        }
    }

    void MoveTarget(Vector3 direction)
    {
        //cube.transform.position += direction;

        LeanTween.moveLocal(cube, cube.transform.localPosition + direction, duration)
                 .setEase(LeanTweenType.easeOutCubic);
    }
}
