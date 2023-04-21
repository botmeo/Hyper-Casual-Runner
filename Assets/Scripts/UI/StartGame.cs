using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void GameStart()
    {
        GameManager.Instance.gameStarted = true;
    }
}
