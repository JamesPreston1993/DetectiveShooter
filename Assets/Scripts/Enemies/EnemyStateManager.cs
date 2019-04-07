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

        attackTargets.playerTransform = null;
    }

    private void SetAttackState(Transform playerTransform)
    {
        attackTargets.enabled = true;
        enemyMovement.enabled = false;

        attackTargets.playerTransform = playerTransform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SetAttackState(other.transform);
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
