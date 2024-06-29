using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Obstacle : MonoBehaviour
{
    public int minPenalty = 1; // �ŏ����_
    public int maxPenalty = 10; // �ő匸�_
    public int probabilityToZeroScore = 5; // �X�R�A��0�ɂ���m���i%�j

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
                    Debug.Log("Random Score Generated: " + penalty); // �����_���ȃX�R�A���f�o�b�O���O�ɕ\��
                    GameManager.Instance.AddScore(-penalty);
                }
            }
            else
            {
                int penalty = Random.Range(minPenalty, maxPenalty + 1);
                Debug.Log("Random Score Generated: " + penalty); // �����_���ȃX�R�A���f�o�b�O���O�ɕ\��
                GameManager.Instance.AddScore(-penalty);
            }
            Destroy(gameObject); // �A�C�e����j��
        }
    }
    private void SetScoreToZero()
    {
        GameManager.Instance.SetScoreToZero();
        Destroy(gameObject);
        Debug.Log("Score has been set to zero!");
    }
}
