using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel2 : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private string sceneName = "Level2";

    public void OnClickLoadScene()
    {
        Time.timeScale = 1f;

        // Gọi MusicManager (nếu muốn stop ngay lập tức)
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopMusic();
        }

        SceneManager.LoadScene(sceneName);
    }
}