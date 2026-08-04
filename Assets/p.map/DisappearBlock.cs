using System.Collections;
using UnityEngine;

public class DisappearBlock : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public IEnumerator Hide(float respawnTime)
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
    }
}