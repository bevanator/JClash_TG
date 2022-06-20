using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
    private float speed = 10f;
    private Vector3 dir = Vector3.right;
    public float Lmax = -10f;
    public float Rmax = 15f;
    public float health = 100f;
    public float descentAmount = 2f;
    public float descentSpeed = 3f;
    public float shootFreq = 2f;
    public GameObject enemyBullet;
    public float shootForce = -50f;
    public bool shoot;
    public float fireRate = 0.5f;
    private float nextFire = 0f;
    [SerializeField] public Invader invaderData;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Descent), descentSpeed, descentSpeed);
        InvokeRepeating(nameof(Shoot), Random.Range(1f, 3f), Random.Range(1f, 3f));
        //fireRate = invaderData.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
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
    
    public void Shoot()
    {
        if (enemyBullet != null)
        {
            var go = Instantiate(enemyBullet, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(new Vector3(0f, shootForce, 0f), ForceMode.Impulse);
            Destroy(go, 5f);
        }

    }
}
