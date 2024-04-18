using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    
    public int coinCount = 0;
    public bool isDead = false;

    public GameObject level;

    public GameObject player;

    public CanvasGroup CoinsPanel;
    [SerializeField] TextMeshProUGUI coinsCounterPlaying;
    [SerializeField] TextMeshProUGUI coinsCounterFinal;

    public CanvasGroup pantallaFinal;

    [SerializeField] TextMeshProUGUI stepsCounterPlaying;
    [SerializeField] TextMeshProUGUI stepsCounterFinal;

    public GameObject pantallaGamePlay;

    public static GameController Instance;

    public CanvasGroup recordSuperado;
    public GameObject crown;

    public GameObject nuevoRecord;

    public CanvasGroup recordResetText;

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
        stepsCounterFinal.text = StepsSystem.Instance.totalSteps.ToString();
        stepsCounterPlaying.text = StepsSystem.Instance.totalSteps.ToString();
        if (StepsSystem.Instance.recordSuperado == true)
        {
            crown.SetActive(true);
            StepsSystem.Instance.recordSuperado = false;
        }

        if (CoinSystem.Instance.monedaRecogida == true)
        {
            coinsCounterPlaying.text = coinCount.ToString("0000");
            coinsCounterFinal.text = coinCount.ToString("0000");
            LeanTween.alphaCanvas(CoinsPanel, 1, 0.2f).setOnComplete(() =>
            {
                LeanTween.alphaCanvas(CoinsPanel, 0, 0.3f).setDelay(0.5f);
                CoinSystem.Instance.monedaRecogida = false;
            });
        }
        if (isDead == true)
        {
            impedirMovimiento();
            pantallaGamePlay.SetActive(false);

            pantallaFinal.gameObject.SetActive(true);
            LeanTween.alphaCanvas(pantallaFinal, 1, 0.5f);
            if (StepsSystem.Instance.recordSuperado == true)
            {
                nuevoRecord.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exitGame()
    {
        Application.Quit();

    }

    public void RestartRecord()
    {
        PlayerPrefs.SetInt(StepsSystem.Instance.recordKey, 0); 
        StepsSystem.Instance.recordSteps = 0;
        LeanTween.alphaCanvas(recordResetText, 1, 0.2f).setOnComplete(() =>
        {
            LeanTween.alphaCanvas(recordResetText, 0, 0.3f).setDelay(0.5f);
            CoinSystem.Instance.monedaRecogida = false;
        });
    }

    void impedirMovimiento()
    {
        LvLMovement lvLMovement = level.GetComponent<LvLMovement>();
        lvLMovement.enabled = false;

        player.gameObject.SetActive(false);
    }

}
