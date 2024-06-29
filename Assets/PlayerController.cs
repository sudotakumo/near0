using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 mid = new Vector3(0, -2, 0);
    private Vector3 left = new Vector3(-3, -2, 0);
    private Vector3 right = new Vector3(3, -2, 0);
    public AudioClip moveSE; // 移動の際に再生する効果音
    private AudioSource audioSource; // AudioSourceコンポーネント
    private KeyCode lastKeyPressed; // 最後に押されたキーを記憶

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        transform.position = left;
        lastKeyPressed = KeyCode.None; // 初期化
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
            lastKeyPressed = KeyCode.A; // 最後に押されたキーを記憶
        }
        else if (Input.GetKey(KeyCode.D) && lastKeyPressed != KeyCode.D)
        {
            rb.MovePosition(right);
            PlayMoveSE();
            lastKeyPressed = KeyCode.D; // 最後に押されたキーを記憶
        }

        transform.Translate(move, 0, 0);
    }
}
