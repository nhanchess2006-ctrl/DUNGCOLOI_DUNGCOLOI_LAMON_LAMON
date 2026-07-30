using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public BoxCollider2D bounds;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private float camHeight;
    private float camWidth;

    void Start()
    {
        Bounds b = bounds.bounds;

        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        minX = b.min.x + camWidth;
        maxX = b.max.x - camWidth;

        minY = b.min.y + camHeight;
        maxY = b.max.y - camHeight;
    }

    void LateUpdate()
    {
        float x = Mathf.Clamp(target.position.x, minX, maxX);
        float y = Mathf.Clamp(target.position.y, minY, maxY);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}