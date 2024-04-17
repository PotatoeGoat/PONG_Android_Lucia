using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public bool monedaRecogida = false;

    public AudioSource coinSound;

    public static CoinSystem Instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            GameController.Instance.coinCount++;
            coinSound.Play();
            other.gameObject.SetActive(false);
            monedaRecogida = true;
        }
    }
}
