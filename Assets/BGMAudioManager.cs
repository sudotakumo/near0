using UnityEngine;
using System.Collections;

public class BGMAudioManager : MonoBehaviour
{
    public static BGMAudioManager Instance;

    public AudioSource audioSource;
    public float fadeDuration = 1.0f;
    public float defaultVolume = 0.2f; // デフォルトの音量を設定できるようにする
    private float targetVolume;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            targetVolume = defaultVolume;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayBGM(AudioClip clip)
    {
        if (audioSource.isPlaying && audioSource.clip == clip)
        {
            return;
        }

        if (audioSource.isPlaying)
        {
            StartCoroutine(FadeOutAndChangeBGM(clip));
        }
        else
        {
            audioSource.clip = clip;
            audioSource.volume = 0;
            audioSource.Play();
            StartCoroutine(FadeInBGM());
        }
    }

    public void StopBGM()
    {
        StartCoroutine(FadeOutBGM());
    }

    public void MuteBGM(bool isMuted)
    {
        audioSource.mute = isMuted;
    }

    private IEnumerator FadeOutAndChangeBGM(AudioClip newClip)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        audioSource.clip = newClip;
        audioSource.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, targetVolume, t / fadeDuration);
            yield return null;
        }
    }

    private IEnumerator FadeInBGM()
    {
        float startVolume = 0;
        audioSource.volume = startVolume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume; // Ensure volume is set to target at the end
    }

    private IEnumerator FadeOutBGM()
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = targetVolume;
    }
}
