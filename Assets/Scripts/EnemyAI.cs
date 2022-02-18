using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;
    Transform target;



    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update() {
        
        if (health.IsDead()) {
            this.enabled = false;
            navMeshAgent.enabled = false;
        }

        // get the distance from enemy to player
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked) {

            EngageWithTarget();

        }
        else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }


    }

    void OnDrawGizmosSelected() {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

    }

    public void OnDamageFromPlayer() {
        isProvoked = true;
    }

    private void EngageWithTarget() {

        RotateToTarget(); // to face the target at every frame
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }

    }
    // deci se intampla sa imi zboare caracterul for some reaseon
    private void ChaseTarget() {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void RotateToTarget() {
        
        Vector3 directionToRotate = (target.position - transform.position).normalized; // to return a vector with a magnitude of 1
        Quaternion lookForRotation = Quaternion.LookRotation(new Vector3(directionToRotate.x, 0, directionToRotate.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookForRotation, Time.deltaTime * turnSpeed);  // spherical interpolation

    }

    private void AttackTarget() {
        GetComponent<Animator>().SetBool("attack", true);
    }

}
