using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }
    [HideInInspector] public bool gameStarted;
    [HideInInspector] public bool gameWon;
    [HideInInspector] public bool gameLost;
    public int playerSize;

    private void Awake()
    {
        instance = this;
        SettingData();
    }

    private void Update()
    {
        if (playerSize <= 0)
        {
            gameLost = true;
        }
    }

    private void SettingData()
    {
        if (!PlayerPrefs.HasKey("Vibrate"))
        {
            PlayerPrefs.SetInt("Vibrate", 1);
        }
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
    }
}
