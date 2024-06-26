using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    public Color fadeColor = Color.black;
    public float defaultFadeDuration = 0.25f; // デフォルトのフェード速度
    private float fadeAlpha = 0;
    private bool isFading = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnGUI()
    {
        if (isFading)
        {
            fadeColor.a = fadeAlpha;
            GUI.color = fadeColor;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        }
    }

    public void LoadScene(string sceneName)
    {
        LoadScene(sceneName, defaultFadeDuration);
    }

    public void LoadScene(string sceneName, float duration)
    {
        if (!isFading)
        {
            StartCoroutine(TransScene(sceneName, duration));
        }
    }

    private IEnumerator TransScene(string sceneName, float duration)
    {
        isFading = true;
        float time = 0;
        while (time <= duration)
        {
            fadeAlpha = Mathf.Lerp(0f, 1f, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);

        time = 0;
        while (time <= duration)
        {
            fadeAlpha = Mathf.Lerp(1f, 0f, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        isFading = false;
    }
}
