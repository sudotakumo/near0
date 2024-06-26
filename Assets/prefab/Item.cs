using UnityEngine;

public class Item : MonoBehaviour
{
    public int minScore = 1; // �ŏ��X�R�A
    public int maxScore = 100; // �ő�X�R�A

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int score = Random.Range(minScore, maxScore + 1);
            Debug.Log("Random Score Generated: " + score); // �����_���ȃX�R�A���f�o�b�O���O�ɕ\��
            GameManager.Instance.AddScore(score);
            Destroy(gameObject);
        }
    }
}
