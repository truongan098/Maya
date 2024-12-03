using UnityEngine;

public class AIRun: MonoBehaviour
{
    private Animator animator; // Animator của nhân vật
    private Rigidbody rb; // Rigidbody của nhân vật (nếu bạn dùng Physics để di chuyển)

    public float moveSpeed = 5f; // Tốc độ di chuyển
    private float speed; // Tốc độ di chuyển thực tế

    void Start()
    {
        // Lấy tham chiếu đến Animator và Rigidbody
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Lấy giá trị di chuyển từ người chơi (hoặc AI)
        float horizontal = Input.GetAxis("Horizontal"); // Di chuyển trái phải
        float vertical = Input.GetAxis("Vertical"); // Di chuyển lên xuống

        // Tính toán tốc độ tổng hợp
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // Cập nhật tham số Speed trong Animator
        speed = movement.magnitude; // Tính tốc độ di chuyển dựa trên vector di chuyển
        animator.SetFloat("Speed", speed);

        // Kiểm tra xem nhân vật có đang chạy hay không
        if (speed > 0.1f)
        {
            animator.SetBool("IsRunning", true); // Nếu di chuyển, bật trạng thái chạy
        }
        else
        {
            animator.SetBool("IsRunning", false); // Nếu dừng lại, tắt trạng thái chạy
        }
    }
}
