using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour, IShooter
{
    private float speed = 10f;
    [SerializeField] [Range(0,1)] float hoverSpeed = 1f;
    [SerializeField] [Range(0,100)] float range = 1f; 
    private Vector3 dir = Vector3.right;
    public float Lmax = -10f;
    public float Rmax = 15f;
    public float health = 100f;
    public float descentAmount = 2f;
    public float descentSpeed = 3f;
    public float shootFreq = 2f;
    public GameObject enemyBullet;
    public GameObject resource;
    public float shootForce = -50f;
    public bool shoot;
    public float fireRate = 0.5f;
    private float nextFire = 0f;
    private bool isDestroyed;
    public bool isSine;
    [SerializeField] public Invader invaderData;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Descent), descentSpeed, descentSpeed);

        fireRate = invaderData.fireRate;
        speed = invaderData.speed/10f;
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
        float y = Mathf.PingPong(Time.time * hoverSpeed, 1) * range;
        if (isSine)
        {
            print(y);
            transform.localPosition += new Vector3(0f, y, 0f);
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"bullet"))
        {
            health -= 20f;
            Destroy(this.gameObject);
        }
        
        if (other.gameObject.CompareTag($"safeZone"))
        {
            UiManager.instance.GameOver();
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
