using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Gravity = 10f; // 중력
    public float Acceleration = 10f; // 가속도
    private float v = 0; // 수직 속도
    
    
    public AudioClip Upsound; // 상승음
    public AudioClip Downsound; // 하강음
    public AudioClip GameOverSound; // 게임 오버음
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        v = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<AudioSource>().PlayOneShot(Upsound);
        }
        if (Input.GetButtonUp("Jump"))
        {
            GetComponent<AudioSource>().PlayOneShot(Downsound);
        }
        if (Input.GetButton("Jump")) // 점프 키를 누르면
        {
            v -= Acceleration * Time.deltaTime; // 가속도만큼 속도 감소
        }
        else
        {
            v += Gravity * Time.deltaTime; // 중력만큼 속도 증가
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * Time.fixedDeltaTime * v); // 아래로 수직 속도만큼 이동
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") // 벽과 충돌하면
        {
            GetComponent<AudioSource>().PlayOneShot(GameOverSound); // 게임 오버음 재생
            int score = (int)GameManager.Instance.Score; // 점수 저장
            PlayerPrefs.SetInt("Score", score); // PlayerPrefs에 저장
            
            SceneManager.LoadScene("GameOverScene"); // 게임 오버 씬으로 이동
        }
    }
}
