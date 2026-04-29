using UnityEngine;

public class GuardAI : MonoBehaviour
{
    [Header("Patrol Settings")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float patrolSpeed = 2f;

    [Header("Chase Settings")]
    [SerializeField] private float detectionRadius = 4f;
    [SerializeField] private float chaseSpeed = 3.5f;
    [SerializeField] private LayerMask playerLayer;

    private Vector3 target;
    private Transform player;
    private bool isChasing = false;

    private void Start()
    {
        target = pointB.position;
    }

    private void Update()
    {
        if (isChasing && player != null)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
            DetectPlayer();
        }
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        if (hit != null)
        {
            player = hit.transform;
            isChasing = true;
            Debug.Log("Guard mulai mengejar Player!");
        }
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.position) < 0.5f)
        {
            Debug.Log("Player tertangkap oleh Guard!");
            FindObjectOfType<GameOverManager>().TriggerGameOver();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}