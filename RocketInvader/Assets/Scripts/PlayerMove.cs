using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IShooter
{

    private float horizontalMove;
    public float speed = 5f;
    public float shootForce = 50f;
    public float bulletOffset = 2f;
    public Animator myAnim;
    private static readonly int SpeedF = Animator.StringToHash("Speed_f");
    public Joystick moveJstick;
    public Joystick aimJstick;
    public GameObject weapon;
    public GameObject bullet;
    public float health = 100f;
    private Quaternion aimRotation;
    private Vector3 aimDirection;
    private bool shoot;
    public float fireRate = 0.5f;
    private float nextFire = 0f;
    private float resourceGauge;
    private Vector3 targetRot;
    private Quaternion rotateToQ;
    
    // Start is called before the first frame update
    void Start()
    {
        resourceGauge = 0;
        shoot = false;
        horizontalMove = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        targetRot = new Vector3(horizontalMove, 0f, 1.0f);
        rotateToQ = Quaternion.LookRotation(targetRot);
        
        horizontalMove = Input.GetAxis("Horizontal");
        if (moveJstick.Horizontal >= 0.02f) horizontalMove = 1f;
        else if (moveJstick.Horizontal <= -0.02f) horizontalMove = -1f;
        else horizontalMove = 0f; 
        
        myAnim.SetFloat(SpeedF, Math.Abs(horizontalMove));
        transform.position += new Vector3(horizontalMove * speed * Time.deltaTime, 0f, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateToQ, speed * Time.deltaTime);
        if(aimJstick.Horizontal!=0f) Aim();
        else
        {
            shoot = false;
            weapon.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (shoot && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) Shoot();

        if(health<=0f) Die();
    }


    public void Shoot()
    {
        var go = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + bulletOffset, transform.position.z), aimRotation);
        go.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, shootForce, 0f), ForceMode.Impulse);
        Destroy(go, 5f);
    }
    
    public void ShootStraight()
    {
        var go = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + bulletOffset, transform.position.z), Quaternion.identity);
        go.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, shootForce, 0f), ForceMode.Impulse);
        Destroy(go, 5f);
    }


    private void Aim()
    {
        weapon.transform.eulerAngles = new Vector3(0f, 0f, aimJstick.Horizontal * -60f);
        aimRotation = Quaternion.Euler(weapon.transform.eulerAngles);
        aimDirection = aimRotation * Vector3.forward;
        shoot = true;
    }

    private void Die()
    {
        myAnim.SetBool("Death_b", true);
        StartCoroutine(ExecuteAfterTime(2f));
    }

    public void SetBool()
    {
        shoot = true;
       
    }
    public void ResetBool()
    {
        shoot = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"resource"))
        {
            //print("hit");
            if(resourceGauge<100f) resourceGauge += 5f;
            Destroy(other.gameObject);
            UiManager.instance.resBar.transform.localScale = new Vector3(resourceGauge / 30.30f, 1f, 1f);
            //print(resourceGauge);
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        UiManager.instance.GameOver();
    }




}
