using UnityEngine;

public class Item : MonoBehaviour
{
    public int minScore = 1; // �ŏ��X�R�A
    public int maxScore = 100; // �ő�X�R�A
    public int probabilityToZeroScore = 5; // �X�R�A��0�ɂ���m���i%�j

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
                    Debug.Log("Random Score Generated: " + score); // �����_���ȃX�R�A���f�o�b�O���O�ɕ\��
                    GameManager.Instance.AddScore(score);
                }
            }
            else
            {
                int score = Random.Range(minScore, maxScore + 1);
                Debug.Log("Random Score Generated: " + score); // �����_���ȃX�R�A���f�o�b�O���O�ɕ\��
                GameManager.Instance.AddScore(score);
            }
            Destroy(gameObject); // �A�C�e����j��
        }
    }

    private void SetScoreToZero()
    {
        GameManager.Instance.SetScoreToZero();
        Debug.Log("Score has been set to zero!");
    }
}
