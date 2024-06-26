using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int minPenalty = 1; // �ŏ����_
    public int maxPenalty = 10; // �ő匸�_

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int penalty = Random.Range(minPenalty, maxPenalty + 1);
            Debug.Log("Random Penalty Generated: " + penalty); // �����_���Ȍ��_���f�o�b�O���O�ɕ\��
            GameManager.Instance.AddScore(-penalty); // �X�R�A�����_
            Destroy(gameObject);
        }
    }
}
