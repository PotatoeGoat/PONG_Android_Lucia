using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPieceLevel : MonoBehaviour
{
    public GameObject[] firstpiece;


    // Start is called before the first frame update
    void Start()
    {
        firstpiece[Random.Range(0, firstpiece.Length)].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
