using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"upperBar"))
        {
            print("hit");
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag($"enemy"))
        {
            print("hit");
            Destroy(this.gameObject);
        }
    }
}
