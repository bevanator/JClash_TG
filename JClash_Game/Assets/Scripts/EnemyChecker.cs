using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag($"enemy"))
        {
            print("enemy detected");
            other.gameObject.GetComponent<EnemyMove>().enabled = true;
            
            var i = Random.Range(1, PlayerManager.instance.players.Count - 1);
            
            other.gameObject.GetComponent<EnemyMove>().target = PlayerManager.instance.players[i];
            PlayerManager.instance.players.RemoveAt(i);
            
            other.gameObject.GetComponent<EnemyMove>().fight = true;
            
            PlayerManager.instance.players[i].GetComponent<PlayerMove>().target = other.gameObject.transform;
            PlayerManager.instance.players[i].GetComponent<PlayerMove>().fight = true;

        }
        

    }
}
