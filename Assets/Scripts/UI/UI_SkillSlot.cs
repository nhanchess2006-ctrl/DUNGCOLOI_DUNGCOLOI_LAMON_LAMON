using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillSlot : MonoBehaviour
{
    private UI ui;
    private Image skillIcon;
    private RectTransform rect;
    private Button button;

    private SkillDataSO skillData;

    public SkillType skillType;
    [SerializeField] private Image cooldownImage;
    [SerializeField] private string inputKeyname;
    [SerializeField] private TextMeshProUGUI inputKeyText;
 


    private void Awake()
    {
        ui = GetComponent<UI>();
        button = GetComponent<Button>();
        skillIcon = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void SetUpSkillSlot(SkillDataSO selectedSkill)
    {
        this.skillData = selectedSkill;

        Color color = Color.black; color.a = 6f;
        cooldownImage.color = color;

        inputKeyText.text = inputKeyname;
        skillIcon.sprite = selectedSkill.icon;
    }    
}
