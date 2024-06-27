using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTextM : MonoBehaviour
{
    public Text resultScore; // �X�R�A��\������e�L�X�g
    public Text key; // �������
    public GameObject zeroScoreImageObject; // �X�R�A��0�̂Ƃ��ɕ\������摜�I�u�W�F�N�g

    // Start is called before the first frame update
    private void Start()
    {
        int score = PlayerPrefs.GetInt("FinalScore");
        if (score == 0)
        {
            resultScore.gameObject.SetActive(false); // �X�R�A�e�L�X�g���\��
            zeroScoreImageObject.SetActive(true); // �X�R�A��0�̂Ƃ��̉摜��\��
            key.color = Color.white;
        }
        else
        {
            resultScore.text = "Score: " + score.ToString();
            resultScore.gameObject.SetActive(true); // �X�R�A�e�L�X�g��\��
            zeroScoreImageObject.SetActive(false); // �X�R�A��0�̂Ƃ��̉摜���\��
            if (Mathf.Abs(score) < 50)
            {
                resultScore.color = Color.white;
                key.color = Color.white;
            }
        }
    }
}
