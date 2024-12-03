using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Transform player; // Drag and drop nhân vật vào đây
    public Transform kickPoint; // Điểm nơi bóng dính vào khi chạm nhân vật
    private bool isAttached = false;

    private Rigidbody rb;
    public Animator animator; // Gắn Animator của nhân vật vào đây

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Khi bóng chạm nhân vật
            isAttached = true;
            rb.isKinematic = true; // Tắt vật lý tạm thời
            transform.position = kickPoint.position; // Đưa bóng tới vị trí kickPoint
            transform.parent = player; // Gắn bóng làm con của nhân vật
        }
    }

    void Update()
    {
        if (isAttached && Input.GetMouseButtonDown(0)) // Chuột trái
        {
            KickBall();
        }
    }

    void KickBall()
    {
        isAttached = false;
        transform.parent = null; // Tách bóng khỏi nhân vật
        rb.isKinematic = false; // Bật lại vật lý
        rb.AddForce(player.forward * 500f + Vector3.up * 200f); // Đẩy bóng theo hướng nhân vật
        animator.SetTrigger("Kick"); // Kích hoạt animation đá
        isAttached = false;
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(player.forward * 500f + Vector3.up * 200f);
    }

}
