using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleportOut;

    private void OnCollisionStay2D(Collision2D other)
    {
        other.gameObject.transform.localPosition = new Vector3(
            teleportOut.transform.position.x,
            teleportOut.transform.position.y,
            other.gameObject.transform.localPosition.z
            );
    }
}
