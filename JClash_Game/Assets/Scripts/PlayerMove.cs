using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Animator playerAController;
    public float speed = 200f;
    public float strafeSpeed = 150f;
    private float horizontalMove;
    private bool moveByKey;
    private static readonly int Run = Animator.StringToHash("Run");
    public Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        //playerRB = transform.GetChild(1).GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxis("Horizontal");
        moveByKey = horizontalMove != 0;
        
        
        if (moveByKey)
        {
            speed = 200f;
            //transform.localPosition += new Vector3(horizontalMove * Time.deltaTime * strafeSpeed, 0f, speed * Time.deltaTime);
            playerAController.SetBool(Run, true);
        }
        else
        {
            speed = 0f;
            playerAController.SetBool(Run, false);
        }

        if (playerRB.velocity.magnitude > 0.5f)
        {
            playerRB.rotation = Quaternion.Slerp(playerRB.rotation, Quaternion.LookRotation(playerRB.velocity, Vector3.up), Time.deltaTime * speed);
        }
        else
        {
            playerRB.rotation = Quaternion.Slerp(playerRB.rotation, Quaternion.identity, Time.deltaTime * speed);
        }
        
    }

    private void FixedUpdate()
    {
        if (moveByKey)
        {
            playerRB.velocity = new Vector3(horizontalMove * Time.deltaTime * strafeSpeed, 0f, speed * Time.deltaTime);
        }
        else playerRB.velocity = Vector3.zero;
    }


}
