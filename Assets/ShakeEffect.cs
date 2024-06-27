using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float amplitude = -0.1f; // �h��̐U��
    public float frequency = 45f; // �h��̎��g��

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition; // �����ʒu��ۑ�
    }

    private void Update()
    {
        // �摜�̈ʒu�������I�ɕύX
        float shakeOffsetX = Mathf.Sin(Time.time * frequency) * amplitude;
        float shakeOffsetY = Mathf.Cos(Time.time * frequency) * amplitude;
        transform.localPosition = initialPosition + new Vector3(shakeOffsetX, shakeOffsetY, 0);
    }
}
