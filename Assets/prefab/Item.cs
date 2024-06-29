using UnityEngine;

public class Item : MonoBehaviour
{
    public int minScore = 1; // 最小スコア
    public int maxScore = 100; // 最大スコア
    public int probabilityToZeroScore = 5; // スコアを0にする確率（%）

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int currentScore = GameManager.Instance.GetScore();
            if (currentScore >= -100 && currentScore <= 0)
            {
                int randomValue = Random.Range(1, 101);
                if (randomValue <= probabilityToZeroScore)
                {
                    SetScoreToZero();
                }
                else
                {
                    int score = Random.Range(minScore, maxScore + 1);
                    Debug.Log("Random Score Generated: " + score); // ランダムなスコアをデバッグログに表示
                    GameManager.Instance.AddScore(score);
                }
            }
            else
            {
                int score = Random.Range(minScore, maxScore + 1);
                Debug.Log("Random Score Generated: " + score); // ランダムなスコアをデバッグログに表示
                GameManager.Instance.AddScore(score);
            }
            Destroy(gameObject); // アイテムを破壊
        }
    }

    private void SetScoreToZero()
    {
        GameManager.Instance.SetScoreToZero();
        Debug.Log("Score has been set to zero!");
    }
}
