using UnityEngine;
using System.Collections;

public class EnemyStateManager : MonoBehaviour
{
    private AttackTargets attackTargets;
    private EnemyMovement enemyMovement;

    void Start()
    {
        attackTargets = GetComponent<AttackTargets>();
        enemyMovement = GetComponent<EnemyMovement>();

        SetMoveState();
    }

    private void SetMoveState()
    {
        attackTargets.enabled = false;
        enemyMovement.enabled = true;
    }

    private void SetAttackState()
    {
        attackTargets.enabled = true;
        enemyMovement.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SetAttackState();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            SetMoveState();
        }
    }
}
