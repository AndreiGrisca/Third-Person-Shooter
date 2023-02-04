using System;
using StarterAssets;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    [SerializeField] private TextMeshProUGUI currentEnemy;
    private int currentEnemeyNumber = 0;
    private int maxKills = 5;

    private void Awake()
    {
        gameManager = this;
        UpdateText();
    }

    private void OnDestroy()
    {
        gameManager = null;
    }

    public void IncreaseScore()
    {
        currentEnemeyNumber++;
        UpdateText();

        if (currentEnemeyNumber >= maxKills)
        {
            UIManager.uiManager.Win();
        }
    }
    
    private void UpdateText()
    {
        currentEnemy.text = "Kills: " + currentEnemeyNumber;
    }
  
}
