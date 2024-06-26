using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int minPenalty = 1; // 最小減点
    public int maxPenalty = 10; // 最大減点

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int penalty = Random.Range(minPenalty, maxPenalty + 1);
            Debug.Log("Random Penalty Generated: " + penalty); // ランダムな減点をデバッグログに表示
            GameManager.Instance.AddScore(-penalty); // スコアを減点
            Destroy(gameObject);
        }
    }
}
