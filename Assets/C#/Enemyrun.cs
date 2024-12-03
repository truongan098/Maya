using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Lấy Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Luôn luôn chuyển sang trạng thái chạy
        SetRunState();
    }

    void SetRunState()
    {
        // Đảm bảo enemy luôn trong trạng thái chạy
        animator.SetBool("isRunning", true);
    }
}
