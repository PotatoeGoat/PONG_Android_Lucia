using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    public float rotationSpeed = 0.25f;

    GameObject chicken;
    public float duration = 0.1f;

    public bool isOnLimit = false;
    public bool isOnLimitFirstTime = false;

    public bool youCanJump = true;
    public bool youCanJumpForward = true;
    public bool youCanJumpRight = true;
    public bool youCanJumpLeft = true;
    public bool youCanJumpBehind = true;
    public bool jump = false;

    public static EventSubscriber Instance;

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

    private void Start()
    {
        chicken = this.gameObject;

        //se suscribe al evento
        SwipeController.Instance.OnSwipeScreen += MoveTarget;

        isOnLimit = false;
    }

    public void OnDisable()
    {
        //En caso de que se elimine el objeto que se suscribe, se elimina la suscripcion
        SwipeController.Instance.OnSwipeScreen -= MoveTarget;
    }

    private void Update()
    {
      
        
    }

    void MoveTarget(Vector3 direction)
    {
        if (direction.x > 0 && youCanJumpRight == true)
        {
            
            MovementTarjet(direction/2);
            RotatePlayer(90f);

        }
        if (direction.x < 0 && youCanJumpLeft == true)
        {
            
            MovementTarjet(direction/2);
            RotatePlayer(-90f);
        }
        if (direction.z > 0 && youCanJumpForward == true)
        {
            if (isOnLimit == false)
            {
                
                MovementTarjet(direction / 2);
            }
            else
            {
                
                MovementTarjet(Vector3.zero);
            }
            
            RotatePlayer(0f);
        }
        if (direction.z < 0 && youCanJumpBehind == true)
        {
            
            MovementTarjet(direction / 2);
            RotatePlayer(-180f);
        }

       
    }

    void MovementTarjet(Vector3 direction)
    {

        youCanJump = false;
        LeanTween.moveLocal(chicken, chicken.transform.position + direction + Vector3.up, duration / 2).setEase(LeanTweenType.easeOutCubic).setOnComplete(() =>
        {
            LeanTween.moveLocal(chicken, chicken.transform.position + direction - Vector3.up, duration / 2).setEase(LeanTweenType.easeOutCubic).setOnComplete(() =>
            {
                youCanJump = true;
                if (isOnLimitFirstTime == true)
                {
                    jump = true;
                }
            });
            
        });
    }

    void RotatePlayer(float angle)
    {
        //transform.eulerAngles = new Vector3(0f, angle, 0f);

        LeanTween.rotateLocal(chicken, new Vector3(0f, angle, 0f),rotationSpeed );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("limit"))
        {
            isOnLimit = true;
            isOnLimitFirstTime = true;
            Debug.Log("IsOnLImit");
        }
        if (other.CompareTag("water"))
        {
            youCanJump = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("limit"))
        {
            isOnLimit = false;
            Debug.Log("NoLImit");

        }

    }

    

}
