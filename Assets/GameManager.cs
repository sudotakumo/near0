using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text scoreText;
    public Text timerText; // タイマーを表示するUIテキスト
    public float gameDuration = 20f; // ゲームの継続時間
    private float remainingTime;
    private long score = 0; // スコアをlong型に変更
    public int minInitialScore = 1; // 初期スコアの最小値
    public int maxInitialScore = 100; // 初期スコアの最大値
    public AudioClip startBGM;
    public AudioClip gameBGM;
    public AudioClip resultBGM;
    public AudioClip score0BGM;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 初期スコアをランダムに設定
        int initialScore = Random.Range(minInitialScore, maxInitialScore + 1);
        AddScore(initialScore);

        remainingTime = gameDuration;
        UpdateScoreText();
        UpdateTimerText();

        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            BGMAudioManager.Instance.PlayBGM(startBGM); // スタートシーンのBGMを再生
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            BGMAudioManager.Instance.PlayBGM(gameBGM); // ゲームシーンのBGMを再生
        }
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;
        UpdateTimerText();

        if (remainingTime <= 0)
        {
            GameOver();
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

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Added Score: " + value + " | Total Score: " + score); // デバッグログを追加
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateTimerText()
    {
        timerText.text = Mathf.Ceil(remainingTime).ToString();
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("FinalScore", (int)score); // スコアを保存
        LoadResultScene();
    }

    private void LoadResultScene()
    {
        if ( PlayerPrefs.GetInt("FinalScore")== 0)
        {
            BGMAudioManager.Instance.PlayBGM(score0BGM); // score0のBGMを再生
        }
        else
        {
            BGMAudioManager.Instance.PlayBGM(resultBGM); // リザルトシーンのBGMを再生
        }
        FadeManager.Instance.LoadScene("ResultScene");
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // ゲームを再開
        FadeManager.Instance.LoadScene(SceneManager.GetActiveScene().name); // 現在のシーンを再読み込み
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1; // ゲームを再開
        BGMAudioManager.Instance.StopBGM(); // タイトル画面に戻るときにBGMを停止
        FadeManager.Instance.LoadScene("StartScene"); // タイトルシーンに遷移（"StartScene"はタイトルシーンの名前）
    }
}
