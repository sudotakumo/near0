using UnityEngine;
using UnityEngine.UI;

public class ZeroScoreEffects : MonoBehaviour
{
    public Image zeroScoreImage;

    private void Start()
    {
        // �X�R�A��0�̂Ƃ��ɏ������������s���܂�
        if (zeroScoreImage != null)
        {
            zeroScoreImage.gameObject.SetActive(true);
            zeroScoreImage.gameObject.AddComponent<ChangeColorRainbow>();
        }

        // ���̃G�t�F�N�g�������ɒǉ��ł��܂�
        // ��: �p�[�e�B�N���G�t�F�N�g�̍Đ�
        // ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        // if (particleSystem != null)
        // {
        //     particleSystem.Play();
        // }
    }

    private void Update()
    {
        // �K�v�ɉ����ăG�t�F�N�g�̍X�V�����������ɒǉ����܂�
    }
}
