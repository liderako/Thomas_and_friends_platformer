using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaControllerY : MonoBehaviour
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
        transform.Translate(new Vector3(0, direction.y * (Time.fixedDeltaTime * speed), 0));

        if (transform.position.y >= originPosition.y + distance)
        {
            direction.y *= -1;
        }
        if (transform.position.y <= originPosition.y - distance)
        {
            direction.y *= -1;
        }
    }
}
