using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Gravity = 10f; // 중력
    public float Acceleration = 10f; // 가속도
    private float v = 0; // 수직 속도
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        v = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
