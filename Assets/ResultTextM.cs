using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTextM : MonoBehaviour
{
    public Text resultScore; // スコアを表示するテキスト
    public Text key; // 操作説明
    public GameObject zeroScoreImageObject; // スコアが0のときに表示する画像オブジェクト

    // Start is called before the first frame update
    private void Start()
    {
        int score = PlayerPrefs.GetInt("FinalScore");
        if (score == 0)
        {
            resultScore.gameObject.SetActive(false); // スコアテキストを非表示
            zeroScoreImageObject.SetActive(true); // スコアが0のときの画像を表示
            key.color = Color.white;
        }
        else
        {
            resultScore.text = "Score: " + score.ToString();
            resultScore.gameObject.SetActive(true); // スコアテキストを表示
            zeroScoreImageObject.SetActive(false); // スコアが0のときの画像を非表示
            if (Mathf.Abs(score) < 50)
            {
                resultScore.color = Color.white;
                key.color = Color.white;
            }
        }
    }
}
