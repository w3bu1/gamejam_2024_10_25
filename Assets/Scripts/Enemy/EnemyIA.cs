using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private Transform prefab;

    [Header("Settings")]
    [SerializeField] private float walkSpeed = 100f;
    [SerializeField] private float chaseSpeed = 200f;
    [SerializeField] private float turnSpeed = 10f;
    [Header("Attack Settings")]
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackTime = 1f;
    [Header("Detection Settings")]
    [SerializeField] private float detectionRange = 10f;
    [Header("Patrol Settings")]
    [SerializeField] private float patrolDistMin = 3f;
    [SerializeField] private float patrolDistMax = 10f;
    [SerializeField] private float waitingTimeMin = 2f;
    [SerializeField] private float waitingTimeMax = 6f;
    [Header("Debug")]
    [SerializeField] private bool isAttacking = false;

    private Vector3 targetPosition;
    private Vector3 knockbackDirection;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        StartCoroutine(Patrol());
        Transform prefabInstance = Instantiate(prefab, transform.position, Quaternion.identity);
        prefabInstance.SetParent(transform);
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < detectionRange)
        {
            agent.speed = chaseSpeed;
            Rotate();
            TakeDecision();
        }
        else
        {
            agent.speed = walkSpeed;
            Move();
        }
    }

    private void TakeDecision()
    {
        if (isAttacking) return;
        if (Vector3.Distance(player.position, transform.position) <= attackRange)
            StartCoroutine(Attack());
        else
            agent.SetDestination(player.position);
    }

    private void Move()
    {
        if (agent.remainingDistance <= 0.75f)
            StartCoroutine(Patrol());
    }

    private void Rotate()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        agent.isStopped = true;
        yield return new WaitForSeconds(attackTime);
        agent.isStopped = false;
        isAttacking = false;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(waitingTimeMin, waitingTimeMax));
    }

    private IEnumerator Patrol()
    {
        yield return new WaitForSeconds(Random.Range(waitingTimeMin, waitingTimeMax));
        targetPosition = transform.position;
        float patrollDistance = Random.Range(patrolDistMin, patrolDistMax);
        targetPosition += patrollDistance * new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPosition, out hit, patrolDistMax, NavMesh.AllAreas))
            agent.SetDestination(hit.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * patrolDistMin);
    }

}
