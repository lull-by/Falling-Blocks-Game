﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;
    float halfScreenWidth;
    float halfPlayerWidth;
    float wrapPosition;
    public event System.Action OnPlayerDeath;
    
    // Start is called before the first frame update
    void Start()
    {
        halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        halfPlayerWidth = (transform.localScale.x)/2f;
        wrapPosition = halfScreenWidth + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -wrapPosition)
        {
            transform.position = new Vector2 (wrapPosition, transform.position.y);
        }
        else if (transform.position.x > wrapPosition)
        {
            transform.position = new Vector2 (-wrapPosition, transform.position.y);;
        }
        Vector2 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        direction = direction.normalized;
        Vector2 velocity = direction * speed;
        Vector2 moveAmount = velocity * Time.deltaTime;
        transform.Translate(moveAmount);
        print("yay");
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "blockPrefab")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
        
    }
    
}
