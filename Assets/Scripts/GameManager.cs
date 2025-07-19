using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public TextMeshProUGUI text;
    private int coin = 0;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());

        if(coin % 10 == 0)
        {
            Player player = FindObjectOfType<Player>();
            if(player != null)
            player.Upgrade();
        }
    }
    public void SetGameOver()
    {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if(enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
        }
    }
}
