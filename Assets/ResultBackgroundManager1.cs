using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class ResultBackgroundManager1 : MonoBehaviour
{
    public Sprite Score50Background; // ��X�R�A���̔w�i
    public Sprite Score100Background; // ���X�R�A���̔w�i
    public Sprite highScoreBackground; // ���X�R�A���̔w�i
    public Sprite jast0Background; // �X�R�A�����傤��0�̂Ƃ��̔w�i
    [SerializeField] float scrollSpeed = 1f;
    private float textureUnitSizeY;
    private Vector2 startPos;
    SpriteRenderer spriteRenderer;
    public Text scoreText; // �X�R�A��\������e�L�X�g
    public GameObject zeroScoreEffectPrefab; // �X�R�A��0�̂Ƃ��̃G�t�F�N�g�p�v���n�u

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        textureUnitSizeY = spriteRenderer.bounds.size.y;
        int score = PlayerPrefs.GetInt("FinalScore");

        if (score == 0)
        {
            spriteRenderer.sprite = jast0Background;
            scoreText.gameObject.SetActive(false); // �X�R�A�e�L�X�g���\��

            // �X�R�A��0�̂Ƃ��̃G�t�F�N�g�𐶐����ĕ\��
            if (zeroScoreEffectPrefab != null)
            {
                Instantiate(zeroScoreEffectPrefab, transform.position, Quaternion.identity);
            }
        }
        else if (Mathf.Abs(score) < 50)
        {
            spriteRenderer.sprite = Score50Background;
            scoreText.text = "Score: " + score.ToString();
        }
        else if (Mathf.Abs(score) < 100)
        {
            spriteRenderer.sprite = Score100Background;
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            spriteRenderer.sprite = highScoreBackground;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void Update()
    {
        if (spriteRenderer.sprite != jast0Background)
        {
            float newPos = Mathf.Repeat(Time.time * scrollSpeed, textureUnitSizeY);
            transform.position = startPos + Vector2.down * newPos;
        }
        else
        {
            transform.position = startPos;
        }

        // �Q�[���̃��Z�b�g
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        // �^�C�g����ʂɖ߂�
        if (Input.GetKeyDown(KeyCode.T))
        {
            ReturnToTitle();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // �Q�[�����ĊJ
        SceneManager.LoadScene("GameScene"); // �Q�[���V�[���ɑJ�ځi"GameScene"�̓Q�[���V�[���̖��O�j
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1; // �Q�[�����ĊJ
        SceneManager.LoadScene("StartScene"); // �^�C�g���V�[���ɑJ�ځi"StartScene"�̓^�C�g���V�[���̖��O�j
    }
}
