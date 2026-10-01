using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBarTwo : MonoBehaviour
{
    public Image enemyHealthBar;
    private EnemyHealthTwo enemyHealth;
    void Start()
    {
        enemyHealth = GetComponentInParent<EnemyHealthTwo>();
    }
    void Update()
    {
        enemyHealthBar.fillAmount = (float)enemyHealth.health / 100;
    }
}
