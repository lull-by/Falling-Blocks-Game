using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float speed = 1f;
    Vector2 halfScreenSize;
    
    // Start is called before the first frame update
    void Start()
    {
        halfScreenSize = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y + transform.localScale.y < -halfScreenSize.y)
        {
            Destroy(gameObject);
        }

    }
}
