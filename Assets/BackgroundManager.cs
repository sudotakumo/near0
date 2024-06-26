using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundScrollController : MonoBehaviour
{
    /// <summary>îwåiÇÃÉXÉNÉçÅ[Éãë¨ìx</summary>
    [SerializeField] float scrollSpeed = 1f;
    SpriteRenderer spriteRenderer;
    private Vector2 startPos;
    private float textureUnitSizeY;
    //private int currentBackgroundIndex = 0;
    public Sprite[] backgrounds;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        textureUnitSizeY = spriteRenderer.bounds.size.y;
        ChangeBackground(0);
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, textureUnitSizeY);
        transform.position = startPos + Vector2.down * newPos;
    }

    /*public void UpdateBackground(int score)
    {
        int newBackgroundIndex = score / 100; // 100ì_Ç≤Ç∆Ç…îwåiÇïœçXÇ∑ÇÈó·

        if (newBackgroundIndex != currentBackgroundIndex && newBackgroundIndex < backgrounds.Length)
        {
            ChangeBackground(newBackgroundIndex);
            currentBackgroundIndex = newBackgroundIndex;
        }
    }*/

    private void ChangeBackground(int index)
    {
        spriteRenderer.sprite = backgrounds[index];
    }
}
