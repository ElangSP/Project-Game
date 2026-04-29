using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    public bool isHidden = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HideSpot"))
        {
            isHidden = true;
            Debug.Log("Player masuk HideSpot → aman");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HideSpot"))
        {
            isHidden = false;
            Debug.Log("Player keluar HideSpot → tidak aman");
        }
    }
}