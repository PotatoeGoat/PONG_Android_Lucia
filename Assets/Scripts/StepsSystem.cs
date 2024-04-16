using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsSystem : MonoBehaviour
{
    int totalSteps = 0;
    int recordSteps = 0; // Variable para almacenar el récord

    public bool recordSuperado = false;

    // La clave para guardar el récord en PlayerPrefs
    string recordKey = "RecordSteps";

    public static StepsSystem Instance;

    private void Awake()
    {
        // Configurar singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Obtener el récord actual guardado en PlayerPrefs
        recordSteps = PlayerPrefs.GetInt(recordKey, 0);

        SwipeController.Instance.OnSwipeScreen += StepsCounter;
    }

    private void OnDisable()
    {
        SwipeController.Instance.OnSwipeScreen -= StepsCounter;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StepsCounter(Vector3 direction)
    {
        if (direction.z > 0 && EventSubscriber.Instance.isOnLimit == true)
        {
            // Incrementar el contador de pasos
            totalSteps++;

            // Comprueba si el nuevo total de pasos supera el récord
            if (totalSteps > recordSteps)
            {
                // Actualiza el récord
                recordSteps = totalSteps;

                recordSuperado = true;

                // Guardar el nuevo récord en PlayerPrefs
                PlayerPrefs.SetInt(recordKey, recordSteps);
                //se guardan los cambios del record
                PlayerPrefs.Save(); 
            }

            // Mostrar el total de pasos y el récord actual
            Debug.Log("Total steps: " + totalSteps + ", Record: " + recordSteps);
        }
    }
}

