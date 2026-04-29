using UnityEngine;

public class GuardDetection : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 4f;
    [SerializeField] private LayerMask playerLayer;

    private string currentStatus = "";

    void Update()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (player != null)
        {
            PlayerStealth stealth = player.GetComponent<PlayerStealth>();
            if (stealth != null && stealth.isHidden)
            {
                currentStatus = "AMAN: Player bersembunyi";
            }
            else
            {
                currentStatus = "KETAHUAN: Game Over!";
            }
        }
        else
        {
            currentStatus = "Player di luar radius";
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 30), currentStatus);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}