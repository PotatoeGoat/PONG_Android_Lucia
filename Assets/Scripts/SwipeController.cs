using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipeController : MonoBehaviour
{
    Vector3 clickInicial;
    Vector3 alsoltarclick;

    public float offset = 100;

    //declarar delegates y events para los movimientos

    public delegate void SwipeScreen(Vector3 direction);
    public event SwipeScreen OnSwipeScreen;

    

    //creamos un singleton
    public static SwipeController Instance;

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

            if (Mathf.Abs(diferencia.magnitude) > offset)
            {
                diferencia = diferencia.normalized;

                diferencia.z = diferencia.y;

                if (Mathf.Abs(diferencia.x)>Mathf.Abs(diferencia.z))
                {
                    diferencia.z = 0.0f;
                }
                else
                {
                    diferencia.x = 0.0f;
                }

                diferencia.y = 0.0f;

                 if (OnSwipeScreen != null)
                {
                    OnSwipeScreen(diferencia);
                }
            }
            
           

            
        }
    }

    
}
