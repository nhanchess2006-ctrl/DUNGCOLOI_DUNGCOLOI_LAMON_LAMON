using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [Header("Delay trước khi biến mất")]
    [SerializeField] private float disappearDelay = 0.2f;

    [Header("Thời gian hồi lại")]
    [SerializeField] private float respawnTime = 5f;

    private List<DisappearBlock> blocks;

    private bool activated = false;

    private void Awake()
    {
        // Lấy Controller (object cha)
        Transform controller = transform.parent;

        // Lấy tất cả Block nằm bên trong Controller
        blocks = new List<DisappearBlock>(
            controller.GetComponentsInChildren<DisappearBlock>()
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
            return;

        if (!other.CompareTag("Player"))
            return;

        StartCoroutine(OpenPlatform());
    }

    IEnumerator OpenPlatform()
    {
        activated = true;

        yield return new WaitForSeconds(disappearDelay);

        foreach (DisappearBlock block in blocks)
        {
            StartCoroutine(block.Hide(respawnTime));
        }

        activated = false;
    }
}