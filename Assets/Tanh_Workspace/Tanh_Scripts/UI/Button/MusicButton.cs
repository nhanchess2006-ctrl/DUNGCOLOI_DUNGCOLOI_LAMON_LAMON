using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// [RequireComponent(typeof(AudioSource))]
public class MusicButton : MonoBehaviour, IPointerDownHandler
{
    // ================= CONFIG =================
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    [Header("Scene Settings")]
    [SerializeField] private string introSceneName = "Intro";

    // ================= STATE =================
    private bool isMusicPlaying = true;
   

    // ================= UNITY =================
    private void Awake()
    {
        // Keep this class independent from AudioManager singleton.
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        ApplyMusicState();
    }

    // ================= SCENE =================
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != introSceneName)
            StopMusic();
    }

    // ================= INPUT =================
    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleMusic();
    }

    // ================= CONTROL =================
    private void ToggleMusic()
    {
        isMusicPlaying = !isMusicPlaying;
        ApplyMusicState();
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();
    }

    private void ApplyMusicState()
    {
        if (isMusicPlaying)
        {
            if (audioSource != null && !audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            StopMusic();
        }
    }
}