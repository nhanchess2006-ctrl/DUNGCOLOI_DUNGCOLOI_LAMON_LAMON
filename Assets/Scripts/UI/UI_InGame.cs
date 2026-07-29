using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour
{
    public Player player;
    private UI_SkillSlot[ ] skillSlots;

    [SerializeField] private RectTransform healthRect;
    [SerializeField] private Slider healthSider;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        player.health.OnHealthUpdate += UpdateHealthBar;

        skillSlots = GetComponentsInChildren<UI_SkillSlot>(true); // CHÍNH XÁC

    }

    public UI_SkillSlot GetSkillSlot(SkillType skillType)
    {
        foreach (var slot in skillSlots)
        {
            if (slot.skillType == skillType)
                return slot;
        }
        return null;
    }

    private void UpdateHealthBar()
    {
        float maxHealth = player.stats.GetMaxHealth();
        float currHealth = player.health.GetCurrentHealth();
        float sizeDiffrent = Mathf.Abs(maxHealth-healthRect.sizeDelta.x);

        if (sizeDiffrent > .1f)
        {
            healthRect.sizeDelta = new Vector2(maxHealth, healthRect.sizeDelta.y);
        }


        healthText.text = currHealth + "/" + maxHealth;
        healthSider.value = player.health.GetHealthPercent();

    }


}
