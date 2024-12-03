using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform ball;
    public Transform ai;
    public float speed = 7f;
    public float stealDistance = 2f;
    public KeyCode stealKey = KeyCode.J;

    private Rigidbody rb;
    private SphereCollider ballCollider; // Collider của bóng
    private Collider playerCollider; // Collider của Player
    public bool hasBall = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballCollider = ball.GetComponent<SphereCollider>();
        playerCollider = GetComponent<Collider>();

        if (ballCollider == null || playerCollider == null)
        {
            Debug.LogError("Không tìm thấy Collider! Đảm bảo bóng và Player có Collider.");
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        if (Input.GetKeyDown(stealKey) && !hasBall)
        {
            TryStealBall();
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(targetRotation);
        }
    }

    void TryStealBall()
    {
        if (ai != null)
        {
            float distanceToAI = Vector3.Distance(transform.position, ai.position);

            if (distanceToAI <= stealDistance)
            {
               /* AIController aiController = ai.GetComponent<AIController>();
                if (aiController != null && aiController.hasBall)
                {
                   *//* aiController.LoseBall();*//*
                    GainBall();
                }*/
            }
        }
    }

    void GainBall()
    {
        hasBall = true;
        Debug.Log("Player đã cướp bóng thành công!");

        // Bỏ qua va chạm giữa Player và bóng
        if (ballCollider != null && playerCollider != null)
        {
            Physics.IgnoreCollision(ballCollider, playerCollider, true);
        }
    }

    public void LoseBall()
    {
        hasBall = false;
        Debug.Log("Player đã mất bóng!");

        // Bật lại va chạm giữa Player và bóng
        if (ballCollider != null && playerCollider != null)
        {
            Physics.IgnoreCollision(ballCollider, playerCollider, false);
        }
    }
}
