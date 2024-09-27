using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText; // 점수 표시 텍스트
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0); // PlayerPrefs에서 점수 불러오기
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTryAgainButtonClicked()
    {
        SceneManager.LoadScene("GameScene"); // 게임 씬으로 이동
    }
    
    public void OnQuitButtonClicked()
    {
        Application.Quit(); // 게임 종료
    }
}
