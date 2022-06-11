using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float horizontalMove;
    public float speed = 5f;
    public float shootForce = 50f;
    public float bulletOffset = 2f;
    public Animator myAnim;
    private static readonly int SpeedF = Animator.StringToHash("Speed_f");
    public Joystick moveJstick;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        horizontalMove = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        //horizontalMove = Input.GetAxis("Horizontal");
        if (moveJstick.Horizontal >= 0.02f) horizontalMove = 1f;
        else if (moveJstick.Horizontal <= -0.02f) horizontalMove = -1f;
        else horizontalMove = 0f;



        myAnim.SetFloat(SpeedF, Math.Abs(horizontalMove));
        transform.position += new Vector3(horizontalMove * speed * Time.deltaTime, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        var go = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + bulletOffset, transform.position.z), Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(new Vector3(0f, shootForce, 0f), ForceMode.Impulse);
    }




}
