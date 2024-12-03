using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float raycastDistance = 1.0f; // Khoảng cách raycast
    public bool isGrounded; // Kiểm tra nếu chạm đất

    void Update()
    {
        // Tạo một raycast từ vị trí của GroundCheck xuống dưới mặt đất
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            isGrounded = true; // Nếu có va chạm, AI đang đứng trên mặt đất
        }
        else
        {
            isGrounded = false; // Nếu không va chạm, AI không đứng trên mặt đất
        }

        // Debug thông tin
        Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.red);
    }
}
