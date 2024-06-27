using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float amplitude = -0.1f; // —h‚ê‚ÌU•
    public float frequency = 45f; // —h‚ê‚Ìü”g”

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition; // ‰ŠúˆÊ’u‚ğ•Û‘¶
    }

    private void Update()
    {
        // ‰æ‘œ‚ÌˆÊ’u‚ğüŠú“I‚É•ÏX
        float shakeOffsetX = Mathf.Sin(Time.time * frequency) * amplitude;
        float shakeOffsetY = Mathf.Cos(Time.time * frequency) * amplitude;
        transform.localPosition = initialPosition + new Vector3(shakeOffsetX, shakeOffsetY, 0);
    }
}
