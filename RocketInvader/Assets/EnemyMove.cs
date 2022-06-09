using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float speed = 10f;
    private Vector3 dir = Vector3.right;
    public float Lmax = -10f;
    public float Rmax = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(transform.localPosition);
        LRMove(speed);
    }

    private void LRMove(float speed)
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (transform.localPosition.z <= Lmax)
        {
            dir = Vector3.right;
        }
        else if (transform.localPosition.z >= Rmax)
        {
            dir = Vector3.left;
        }
    }
}
