using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject WallPrefab; // 벽 프리팹
    public float WallSpawnTime = 4; // 벽 생성 주기
    private float score;
    float spawnTimer;// 벽 생성 타이머

    public float Score
    {
        get
        {
            return score;
        }
    }

    private void Awake()
    {
        Instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime; // 타이머 증가
        score += Time.deltaTime; // 점수 증가
        
        if (spawnTimer > WallSpawnTime) // 생성 주기마다
        {
            spawnTimer -= WallSpawnTime; // 타이머 초기화
            GameObject obj = Instantiate(WallPrefab);
            obj.transform.position = new Vector2(10, Random.Range(-2f, 2f)); // 오른쪽에서 생성
        }
    }
}
