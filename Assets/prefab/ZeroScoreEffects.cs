using UnityEngine;
using UnityEngine.UI;

public class ZeroScoreEffects : MonoBehaviour
{
    public Image zeroScoreImage;

    private void Start()
    {
        // スコアが0のときに初期化処理を行います
        if (zeroScoreImage != null)
        {
            zeroScoreImage.gameObject.SetActive(true);
            zeroScoreImage.gameObject.AddComponent<ChangeColorRainbow>();
        }

        // 他のエフェクトをここに追加できます
        // 例: パーティクルエフェクトの再生
        // ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        // if (particleSystem != null)
        // {
        //     particleSystem.Play();
        // }
    }

    private void Update()
    {
        // 必要に応じてエフェクトの更新処理をここに追加します
    }
}
