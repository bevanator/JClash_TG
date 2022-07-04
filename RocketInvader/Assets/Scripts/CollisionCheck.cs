using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public GameObject resource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"upperBar"))
        {
            //print("hit");
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag($"enemy"))
        {
            Instantiate(resource, other.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
