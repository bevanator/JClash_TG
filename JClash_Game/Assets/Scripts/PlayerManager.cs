using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    //public Animator playerAController;
    public List<Transform> players = new List<Transform>();
    public float speed = 5f;
    public float strafeSpeed = 4f;
    private float horizontalMove;
    private bool moveByKey;
    private static readonly int Run = Animator.StringToHash("Run");
    // Start is called before the first frame update
    
    
    #region Singleton

    public static PlayerManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }
    #endregion
    void Start()
    {
        players.Add(transform.GetChild(0));

    }





}
