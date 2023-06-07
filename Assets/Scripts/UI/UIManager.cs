using DG.Tweening;
using PathCreation.Examples;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider process;

    private void Start()
    {
        settingUI.transform.localScale = Vector3.zero;
        gameUI.SetActive(true);
    }

    private void Update()
    {
        if (GameManager.Instance.gameStarted)
        {
            DeactivateUI(menuUI);
            DeactivateUI(tutorialUI);
        }

        if (GameManager.Instance.gameWon)
        {
            ActivateUI(winUI);
        }
        if (GameManager.Instance.gameLost)
        {
            ActivateUI(loseUI);
        }
        SetLevelText();
        SetProcessLevel();
    }

    private void ActivateUI(GameObject menu)
    {
        gameUI.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(false);

        menu.SetActive(true);
    }

    private void DeactivateUI(GameObject menu)
    {
        menu.SetActive(false);
    }

    private void SetLevelText()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        levelText.text = currentLevel.ToString();
    }

    private void SetProcessLevel()
    {
        process.value = PathFollower.Instance.pathProgress;
    }

    public void OpenSettings()
    {
        gameUI.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(false);

        settingUI.SetActive(true);
        settingUI.transform.DOScale(Vector3.one, 1);
    }

    public void CloseSettings()
    {
        settingUI.SetActive(false);
        gameUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        int newCurrentLevel = PlayerPrefs.GetInt("CurrentLevel") + 1;
        int newLoadingLevel = PlayerPrefs.GetInt("LoadingLevel") + 1;

        if (newLoadingLevel >= SceneManager.sceneCountInBuildSettings)
        {
            newLoadingLevel = 1;
        }

        PlayerPrefs.SetInt("CurrentLevel", newCurrentLevel);
        PlayerPrefs.SetInt("LoadingLevel", newLoadingLevel);

        SceneManager.LoadScene(newLoadingLevel);
    }
}
