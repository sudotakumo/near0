using UnityEngine;

public class Item : MonoBehaviour
{
    public int minScore = 1; // 最小スコア
    public int maxScore = 100; // 最大スコア

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int score = Random.Range(minScore, maxScore + 1);
            Debug.Log("Random Score Generated: " + score); // ランダムなスコアをデバッグログに表示
            GameManager.Instance.AddScore(score);
            Destroy(gameObject);
        }
    }
}
