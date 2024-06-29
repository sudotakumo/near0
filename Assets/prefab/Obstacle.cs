using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Obstacle : MonoBehaviour
{
    public int minPenalty = 1; // 最小減点
    public int maxPenalty = 10; // 最大減点
    public int probabilityToZeroScore = 5; // スコアを0にする確率（%）

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int currentScore = GameManager.Instance.GetScore();
            if (currentScore <= 100&&currentScore>= 0)
            {
                int randomValue = Random.Range(1, 101);
                if (randomValue <= probabilityToZeroScore)
                {
                    SetScoreToZero();
                }
                else
                {
                    int penalty = Random.Range(minPenalty, maxPenalty + 1);
                    Debug.Log("Random Score Generated: " + penalty); // ランダムなスコアをデバッグログに表示
                    GameManager.Instance.AddScore(-penalty);
                }
            }
            else
            {
                int penalty = Random.Range(minPenalty, maxPenalty + 1);
                Debug.Log("Random Score Generated: " + penalty); // ランダムなスコアをデバッグログに表示
                GameManager.Instance.AddScore(-penalty);
            }
            Destroy(gameObject); // アイテムを破壊
        }
    }
    private void SetScoreToZero()
    {
        GameManager.Instance.SetScoreToZero();
        Destroy(gameObject);
        Debug.Log("Score has been set to zero!");
    }
}
