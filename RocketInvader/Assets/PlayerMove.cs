using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float horizontalMove;
    public float speed = 5f;
    public Animator myAnim;
    private static readonly int SpeedF = Animator.StringToHash("Speed_f");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        myAnim.SetFloat(SpeedF, Math.Abs(horizontalMove));
        transform.position += new Vector3(horizontalMove * speed * Time.deltaTime, 0f, 0f);
    }
}
