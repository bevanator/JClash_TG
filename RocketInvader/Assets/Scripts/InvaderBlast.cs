using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class InvaderBlast : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] private GameObject getHealthSystemGameObject;

    private void Start() {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"upperBar"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag($"Player"))
        {
            //print("hit");
            Destroy(this.gameObject);
            other.GetComponent<PlayerMove>().health -= 10f;
            getHealthSystemGameObject = other.gameObject;
            HealthSystem.TryGetHealthSystem(getHealthSystemGameObject, out HealthSystem healthSystem, true);
            healthSystem.Damage(10);
        }
    }
}
