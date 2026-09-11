using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBar : MonoBehaviour
{
    public Image enemyHealthBar;
    private EnemyHealth enemyHealth;
    void Start()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }
    void Update()
    {
        enemyHealthBar.fillAmount = (float)enemyHealth.health / 100; 
    }
}
