using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float scoreForItem = 10f;

    Rigidbody2D rb;
    Transform myTransform;

    private Vector2 velocity;
    private float playerSpeed;
    private float minX;
    private float maxX;
    private float offset=1.2f;
    private float xPos = 0f;
    private float middleOfTheScreen = 0.5f;

    public event Action<float> OnGetBanana;
    public event Action OnTouchBomb;

    private void Awake()
    {
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(speed, 0);
    }

    private void Start()
    {
        CheckScreenBorders();
    }

    private void Update()
    {
        ClampPosition();

        TouchBehaviour();
    }

    private void ClampPosition()
    {
        float posX = Mathf.Clamp(transform.position.x, minX, maxX);
        myTransform.position = new Vector2(posX, myTransform.position.y);
    }

    private void TouchBehaviour()
    {
        xPos = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new Vector2(xPos * speed, 0);
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if(EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        //    {

        //        if (touch.phase == TouchPhase.Began)
        //        {
        //            if (touch.position.x > middleOfTheScreen)
        //        {
        //            rb.velocity = velocity;
        //        }
        //        else if (touch.position.x < middleOfTheScreen) 
        //            {
        //                rb.velocity = velocity * -1;
        //            }
        //        }
        //        else if (touch.phase == TouchPhase.Ended)
        //        {
        //            rb.velocity=velocity * 0;
        //        }
        //    }
        //}
    }

    private void CheckScreenBorders()
    {
        minX = Camera.main.ViewportToWorldPoint(Vector3.zero).x + offset;
        maxX = Camera.main.ViewportToWorldPoint(Vector3.right).x - offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Banana"))
        {
            OnGetBanana(scoreForItem);
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("Bomb"))
        {
            OnTouchBomb();
            Destroy(collision.gameObject);
        }
    }
}
