using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public AudioClip startBGM;
    public Button muteButton;
    private bool isMuted = false;

    private void Start()
    {
        BGMAudioManager.Instance.PlayBGM(startBGM); // �X�^�[�g�V�[����BGM���Đ�

        muteButton.onClick.AddListener(ToggleMute);
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;
        BGMAudioManager.Instance.MuteBGM(isMuted);
    }
}
