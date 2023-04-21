using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    /*[SerializeField] private GameObject*/
    private void Awake()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LoadingLevel", 1));
    }
}
