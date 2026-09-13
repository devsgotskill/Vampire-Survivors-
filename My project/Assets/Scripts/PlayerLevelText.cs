using UnityEngine;
using TMPro;

public class PlayerLevelText : MonoBehaviour
{
    private PlayerXp playerXp;
    private TMP_Text levelText;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerXp = playerObject.GetComponent<PlayerXp>();
        levelText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        levelText.text = ""+playerXp.level;
    }
}