using UnityEngine;
using TMPro; // TextMeshPro
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText; // Hiển thị tỷ số
    public Button resetButton; // Nút Reset
    public CanvasGroup uiCanvasGroup; // CanvasGroup để ẩn/hiện UI

    private int player1Score = 0; // Điểm của Player 1
    private int player2Score = 0; // Điểm của Player 2

    void Start()
    {
        HideUI(); // Ẩn UI khi bắt đầu
        resetButton.onClick.AddListener(ResetGame);
        UpdateScoreUI(); // Cập nhật tỷ số ban đầu
    }

    public void GoalScored(string scoringPlayer)
    {
        if (scoringPlayer == "Player1")
        {
            player1Score++; // Tăng điểm cho Player 1
        }
        else if (scoringPlayer == "Player2")
        {
            player2Score++; // Tăng điểm cho Player 2
        }

        UpdateScoreUI(); // Cập nhật tỷ số
        ShowUI(); // Hiển thị UI khi có bàn thắng
    }

    void UpdateScoreUI()
    {
        scoreText.text = $"Player 1: {player1Score} - Player 2: {player2Score}";
    }

    void ResetGame()
    {
        player1Score = 0; // Reset điểm Player 1
        player2Score = 0; // Reset điểm Player 2
        UpdateScoreUI(); // Cập nhật giao diện
        HideUI(); // Ẩn UI sau khi reset

        // Load lại scene để reset trạng thái game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ShowUI()
    {
        // Hiển thị UI bằng cách điều chỉnh CanvasGroup
        uiCanvasGroup.alpha = 1;
        uiCanvasGroup.interactable = true;
        uiCanvasGroup.blocksRaycasts = true;
    }

    void HideUI()
    {
        // Ẩn UI bằng cách điều chỉnh CanvasGroup
        uiCanvasGroup.alpha = 0;
        uiCanvasGroup.interactable = false;
        uiCanvasGroup.blocksRaycasts = false;
    }
}