using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public string scoringPlayer; // Player1 hoặc Player2
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Gắn tag "Ball" cho trái bóng
        {
            gameManager.GoalScored(scoringPlayer);
        }
    }
}
