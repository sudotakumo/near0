using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class ResultBackgroundManager1 : MonoBehaviour
{
    public Sprite Score50Background; // 低スコア時の背景
    public Sprite Score100Background; // 中スコア時の背景
    public Sprite highScoreBackground; // 高スコア時の背景
    public Sprite jast0Background; // スコアがちょうど0のときの背景
    [SerializeField] float scrollSpeed = 1f;
    private float textureUnitSizeY;
    private Vector2 startPos;
    SpriteRenderer spriteRenderer;
    public Text scoreText; // スコアを表示するテキスト
    public GameObject zeroScoreEffectPrefab; // スコアが0のときのエフェクト用プレハブ

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        textureUnitSizeY = spriteRenderer.bounds.size.y;
        int score = PlayerPrefs.GetInt("FinalScore");

        if (score == 0)
        {
            spriteRenderer.sprite = jast0Background;
            scoreText.gameObject.SetActive(false); // スコアテキストを非表示

            // スコアが0のときのエフェクトを生成して表示
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

        // ゲームのリセット
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        // タイトル画面に戻る
        if (Input.GetKeyDown(KeyCode.T))
        {
            ReturnToTitle();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // ゲームを再開
        SceneManager.LoadScene("GameScene"); // ゲームシーンに遷移（"GameScene"はゲームシーンの名前）
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1; // ゲームを再開
        SceneManager.LoadScene("StartScene"); // タイトルシーンに遷移（"StartScene"はタイトルシーンの名前）
    }
}
