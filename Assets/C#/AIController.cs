using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform ball; // Trái bóng
    public Transform player; // Người chơi
    public float stealRange = 1.5f; // Phạm vi để cướp bóng

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Đuổi theo bóng
        agent.SetDestination(ball.position);

        // Kiểm tra khoảng cách giữa AI và bóng
        if (Vector3.Distance(transform.position, ball.position) <= stealRange)
        {
            StealBall();
        }
    }

    void StealBall()
    {
        // Gán bóng cho AI
        ball.SetParent(transform);
        ball.localPosition = new Vector3(0, 1, 1); // Đặt bóng trước mặt AI
    }
}
