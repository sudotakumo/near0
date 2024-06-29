using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 mid = new Vector3(0, -2, 0);
    private Vector3 left = new Vector3(-3, -2, 0);
    private Vector3 right = new Vector3(3, -2, 0);
    public AudioClip moveSE; // �ړ��̍ۂɍĐ�������ʉ�
    private AudioSource audioSource; // AudioSource�R���|�[�l���g
    private KeyCode lastKeyPressed; // �Ō�ɉ����ꂽ�L�[���L��

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        transform.position = left;
        lastKeyPressed = KeyCode.None; // ������
    }

    private void Update()
    {
        MovePlayer();
    }
    private void PlayMoveSE()
    {
        audioSource.clip = moveSE;
        audioSource.Play();
    }
    private void MovePlayer()
    {
        float move = 0;

        if (Input.GetKey(KeyCode.A) && lastKeyPressed != KeyCode.A)
        {
            rb.MovePosition(left);
            PlayMoveSE();
            lastKeyPressed = KeyCode.A; // �Ō�ɉ����ꂽ�L�[���L��
        }
        else if (Input.GetKey(KeyCode.D) && lastKeyPressed != KeyCode.D)
        {
            rb.MovePosition(right);
            PlayMoveSE();
            lastKeyPressed = KeyCode.D; // �Ō�ɉ����ꂽ�L�[���L��
        }

        transform.Translate(move, 0, 0);
    }
}
