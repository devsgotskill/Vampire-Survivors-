using UnityEngine;
using UnityEngine.UI;

public class dashKnob : MonoBehaviour
{
    public Image cooldownImage;
    public float rotationSpeed = 100f;
    private Player player;

    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    void Update()
    {
        cooldownImage.fillAmount = player.dashCooldownTimer / player.dashCooldown;
        cooldownImage.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
