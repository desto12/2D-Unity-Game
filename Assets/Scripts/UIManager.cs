using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Ui is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public Text gemsCount;
    public Text hudGemsCount;
    public Image[] hudHealthBar;

    public void OpenShop(int gCount)
    {
        gemsCount.text = ""+gCount+"D";
    }

    public void UpdateDiamnodsCount(int count)
    {
        hudGemsCount.text = " "+count;
    }

    public void UpdateLives(int health)
    {
        Debug.Log("zdrowie " + health);
        for (int i = 0; i <= health; i ++)
        {
            if (i == health)
            {
                hudHealthBar[i].enabled = false;
            }
        }
    }

}
