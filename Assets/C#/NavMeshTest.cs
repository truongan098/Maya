using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{
    public Transform target; // Điểm đích cho AI

    private NavMeshAgent agent;
    
    void Start()
    {
        // Lấy thành phần NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // Kiểm tra nếu agent không null và NavMeshAgent đã được đặt trên NavMesh
        if (agent != null && agent.isOnNavMesh)
        {
            agent.SetDestination(target.position); // Đặt mục tiêu cho AI
        }
        // Nếu bạn muốn bỏ qua, có thể để trống ở đây hoặc thực hiện hành động khác
    }
}
