using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recruiter : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {

        if (other.collider.CompareTag($"wall"));
        
        if (other.collider.CompareTag($"recruit"))
        {
            PlayerManager.instance.players.Add(other.collider.transform);
            other.transform.SetParent(PlayerManager.instance.transform);
            other.transform.gameObject.GetComponent<PlayerMove>().enabled = true;

        }
    }
}
