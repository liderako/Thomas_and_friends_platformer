using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeButton : MonoBehaviour
{
    public GameObject door;

    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isOpen && other.gameObject.layer == 13)
        {
            isOpen = true;
            door.gameObject.layer = 10;
            door.GetComponent<SpriteRenderer>().color = new Color(r: 0.6226415f, g: 0.2169935f, b:0.1967782f);
        }
    }
}
