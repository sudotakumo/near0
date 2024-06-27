using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float amplitude = -0.1f; // 揺れの振幅
    public float frequency = 45f; // 揺れの周波数

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition; // 初期位置を保存
    }

    private void Update()
    {
        // 画像の位置を周期的に変更
        float shakeOffsetX = Mathf.Sin(Time.time * frequency) * amplitude;
        float shakeOffsetY = Mathf.Cos(Time.time * frequency) * amplitude;
        transform.localPosition = initialPosition + new Vector3(shakeOffsetX, shakeOffsetY, 0);
    }
}
