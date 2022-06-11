using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Animator playerAController;
    public float speed = 5f;
    public float strafeSpeed = 4f;
    private float horizontalMove;
    private bool moveByKey;
    public bool fight;
    public bool reached;
    public Transform target;
    private Rigidbody rb;
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Die = Animator.StringToHash("Die");
    // Start is called before the first frame update
    void Start()
    {
        fight = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxis("Horizontal");
        Vector3 targetRot = new Vector3(horizontalMove, 0f, 1.0f);
        Quaternion rotateToQ = Quaternion.LookRotation(targetRot);

        moveByKey = horizontalMove != 0;



        if (fight)
        {
            transform.LookAt(target);
            if (!reached)
            {
                playerAController.SetBool(Run, true);
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.position, Time.deltaTime * speed * 2f);
            }
        }
        else
        {
            if (moveByKey)
            {
                speed = 5f;
                transform.localPosition += new Vector3(horizontalMove * Time.deltaTime * strafeSpeed, 0f, speed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotateToQ, speed * Time.deltaTime);
                playerAController.SetBool(Run, true);
            }
            else
            {
                speed = 0f;
                playerAController.SetBool(Run, false);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, speed * Time.deltaTime);
            }
        }
        

        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag($"enemy"))
        {
            reached = true;
            playerAController.SetBool(Die, true);
            //playerAController.SetBool(Run, false);
            Destroy(rb);
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<PlayerMove>().enabled = false;
        }
    }



}
