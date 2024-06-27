using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text scoreText;
    public Text timerText; // �^�C�}�[��\������UI�e�L�X�g
    public float gameDuration = 20f; // �Q�[���̌p������
    private float remainingTime;
    private long score = 0; // �X�R�A��long�^�ɕύX
    public int minInitialScore = 1; // �����X�R�A�̍ŏ��l
    public int maxInitialScore = 100; // �����X�R�A�̍ő�l
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
        // �����X�R�A�������_���ɐݒ�
        int initialScore = Random.Range(minInitialScore, maxInitialScore + 1);
        AddScore(initialScore);

        remainingTime = gameDuration;
        UpdateScoreText();
        UpdateTimerText();

        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            BGMAudioManager.Instance.PlayBGM(startBGM); // �X�^�[�g�V�[����BGM���Đ�
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            BGMAudioManager.Instance.PlayBGM(gameBGM); // �Q�[���V�[����BGM���Đ�
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

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Added Score: " + value + " | Total Score: " + score); // �f�o�b�O���O��ǉ�
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
        PlayerPrefs.SetInt("FinalScore", (int)score); // �X�R�A��ۑ�
        LoadResultScene();
    }

    private void LoadResultScene()
    {
        if ( PlayerPrefs.GetInt("FinalScore")== 0)
        {
            BGMAudioManager.Instance.PlayBGM(score0BGM); // score0��BGM���Đ�
        }
        else
        {
            BGMAudioManager.Instance.PlayBGM(resultBGM); // ���U���g�V�[����BGM���Đ�
        }
        FadeManager.Instance.LoadScene("ResultScene");
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // �Q�[�����ĊJ
        FadeManager.Instance.LoadScene(SceneManager.GetActiveScene().name); // ���݂̃V�[�����ēǂݍ���
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1; // �Q�[�����ĊJ
        BGMAudioManager.Instance.StopBGM(); // �^�C�g����ʂɖ߂�Ƃ���BGM���~
        FadeManager.Instance.LoadScene("StartScene"); // �^�C�g���V�[���ɑJ�ځi"StartScene"�̓^�C�g���V�[���̖��O�j
    }
}
