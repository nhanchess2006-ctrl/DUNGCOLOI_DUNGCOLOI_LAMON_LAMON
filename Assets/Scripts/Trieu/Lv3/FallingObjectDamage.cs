using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingObjectDamage : MonoBehaviour
{
    [Header("Cài đặt sát thương")]
    public float damageAmount = -200f; // Sát thương vật lý
    public float elementalDamageAmount = 0f; // Sát thương nguyên tố (nếu có)
    
    public string playerTag = "Player";
    
    [Header("Hiệu ứng (Tuỳ chọn)")]
    public GameObject impactEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu chạm trúng người chơi
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Lấy component Entity_Health từ nhân vật
            Entity_Health playerHealth = collision.gameObject.GetComponent<Entity_Health>();
            
            if (playerHealth != null)
            {
                // Gọi trực tiếp hàm TakeDamage với 4 tham số.
                // - Tham số thứ 3 (ElementType): Tôi dùng từ khoá 'default' để lấy giá trị mặc định của enum. 
                //   Nếu game bạn có hệ vô thuộc tính (VD: ElementType.None hoặc ElementType.Physical), bạn có thể thay 'default' bằng tên đó.
                // - Tham số thứ 4 (damageDealer): Truyền 'transform' của vật thể rơi vào để script của bạn tính toán hướng Knockback.
                
                playerHealth.TakeDamage(damageAmount, elementalDamageAmount, default, this.transform);
            }
            
            DestroyHazard();
        }
        else
        {
            // Nếu chạm mặt đất hoặc các vật thể khác (không phải Player)
            DestroyHazard();
        }
    }

    private void DestroyHazard()
    {
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}