using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Animator playerAController;
    public float speed = 5f;
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

        if (fight)
        {
            transform.LookAt(target);
            if (!reached)
            {
                playerAController.SetBool(Run, true);
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.position, Time.deltaTime * speed);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag($"recruit"))
        {
            reached = true;
            playerAController.SetBool(Die, true);
            //playerAController.SetBool(Run, false);
            Destroy(rb);
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<EnemyMove>().enabled = false;
        }
    }
}
