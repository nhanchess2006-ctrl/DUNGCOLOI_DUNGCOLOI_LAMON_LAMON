using UnityEngine;
using UnityEngine.Video; // Bắt buộc phải có để điều khiển Video Player
using UnityEngine.SceneManagement; // Bắt buộc phải có để chuyển Scene

public class IntroVideoController : MonoBehaviour
{
    [Header("Cấu hình Video")]
    [SerializeField] private VideoPlayer videoPlayer; // Kéo Video Player vào đây

    [Header("Cấu hình Chuyển Cảnh")]
    [SerializeField] private string sceneToLoad = "IntroScene"; // Tên Scene tiếp theo bạn muốn chuyển tới

    private bool isTransitioning = false; // Biến chặn để tránh gọi chuyển cảnh nhiều lần cùng lúc

    void Awake()
    {
        // Tự động tìm thành phần VideoPlayer nếu chưa kéo thả trong Inspector
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();
    }

    void OnEnable()
    {
        if (videoPlayer != null)
        {
            // Đăng ký sự kiện: Khi video chạy hết thời lượng, tự động gọi hàm VideoFinished
            videoPlayer.loopPointReached += VideoFinished;
        }
    }

    void OnDisable()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= VideoFinished;
        }
    }

    void Update()
    {
        // Kiểm tra nếu người chơi ấn BẤT KỲ phím nào trên bàn phím hoặc click chuột/chạm màn hình
        if (Input.anyKeyDown && !isTransitioning)
        {
            // Debug.Log("Người chơi bấm phím để bỏ qua (Skip) Video Intro!");
            LoadNextScene();
        }
    }

    // Hàm tự động kích hoạt khi video kết thúc hoàn toàn
    void VideoFinished(VideoPlayer source)
    {
        if (!isTransitioning)
        {
            // Debug.Log("Video Intro đã phát xong hoàn toàn!");
            LoadNextScene();
        }
    }

    // Hàm xử lý chuyển đổi Scene an toàn
    void LoadNextScene()
    {
        isTransitioning = true; // Khóa lệnh lại không cho chạy trùng lặp

        // Dừng video lại trước khi chuyển cảnh
        if (videoPlayer != null && videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }

        // Tải Scene chỉ định
        SceneManager.LoadScene(sceneToLoad);
    }
}
