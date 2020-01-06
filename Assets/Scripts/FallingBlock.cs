using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float speed = 0.1f;
    static float bottomOfScreen;

    // Start is called before the first frame update
    void Start()
    {
        bottomOfScreen = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        if (transform.position.x < -bottomOfScreen)
        {
            Destroy(transform.gameObject);
        }

    }
}
