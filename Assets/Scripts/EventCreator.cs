using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCreator : MonoBehaviour
{
    public delegate void PresionaEnter();
    public event PresionaEnter OnPresionarEnter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            //si algun objeto está escuchando, entonces, ese objeto suscrito, hará su función
            if (OnPresionarEnter != null)
            {
                OnPresionarEnter();
            }
        }
    }
}
