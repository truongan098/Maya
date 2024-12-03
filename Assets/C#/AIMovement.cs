using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GroundCheck groundCheck; // Tham chiếu đến script GroundCheck
    public float moveSpeed = 5f;

    private void Update()
    {
        // Kiểm tra nếu nhân vật đang chạm đất
        if (groundCheck.isGrounded)
        {
            // Di chuyển AI (ví dụ: tiến tới mục tiêu)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Nhân vật không chạm đất! Không thể di chuyển.");
        }
    }
}
