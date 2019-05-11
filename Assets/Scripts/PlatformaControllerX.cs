using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaControllerX : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 originPosition;
    public Vector2 direction;
    public int distance;
    
    void Start()
    {
       originPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(direction.x * (Time.fixedDeltaTime * speed), 0, 0));

        if (transform.position.x >= originPosition.x + distance)
        {
            direction.x *= -1;
        }
        if (transform.position.x <= originPosition.x - distance)
        {
            direction.x *= -1;
        }
    }
}

