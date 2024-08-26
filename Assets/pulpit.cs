using UnityEngine;

public class Pulpit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.IncreaseScore();
            }
            Destroy(gameObject);
        }
    }
}
