using UnityEngine;
using UnityEngine.Serialization;

public class Background : MonoBehaviour
{
    public float With = 19.2f; // 배경의 너비
    public float Speed = 3; // 배경의 속도
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * Speed); //vector2.left 방향으로 deltaTime 만큼 이동
        
        if (transform.position.x < -With) // 배경이 왼쪽으로 벗어나면
        {
            transform.Translate(Vector2.right * With * 2); // 오른쪽으로 너비의 2배만큼 이동
        }
    }
}
