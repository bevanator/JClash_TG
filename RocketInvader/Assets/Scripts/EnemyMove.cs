using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float speed = 10f;
    private Vector3 dir = Vector3.right;
    public float Lmax = -10f;
    public float Rmax = 15f;
    public float health = 100f;
    public float descentAmount = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Descent), 4f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        //print(transform.localPosition);
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
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"bullet"))
        {
            health -= 20f;
            Destroy(this.gameObject);
        }
    }

    void Descent()
    {
        transform.position -= new Vector3(0f, descentAmount, 0f);
    }
}
