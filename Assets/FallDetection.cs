using UnityEngine;

public class FallDetection : MonoBehaviour
{
    public float fallThreshold = -10f; 
    private void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        if (GameOverManager.instance != null)
        {
            GameOverManager.instance.ShowGameOver();
        }
        else
        {
            Debug.LogError("GameOverManager instance is null.");
        }
    }
}
