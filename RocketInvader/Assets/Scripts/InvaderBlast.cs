using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class InvaderBlast : MonoBehaviour
{
    float health;
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
            
            if(other.GetComponent<PlayerMove>().health>0f) health = other.GetComponent<PlayerMove>().health -= 2f;
            /*
            getHealthSystemGameObject = other.gameObject;
            HealthSystem.TryGetHealthSystem(getHealthSystemGameObject, out HealthSystem healthSystem, true);
            healthSystem.Damage(10);
            */
            UiManager.instance.healthBar.transform.localScale = new Vector3(health / 30.30f, 1f, 1f);
        }
    }
}
