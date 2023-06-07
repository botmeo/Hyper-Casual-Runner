using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    [SerializeField] private TextMeshPro sizeText;
    private float currentSize = 1;

    private void Update()
    {
        StartCoroutine(UpdatePlayerSize());
    }

    private IEnumerator UpdatePlayerSize()
    {
        yield return new WaitUntil(() => GameManager.Instance != null);

        float playerSize = GameManager.Instance.playerSize;
        float size = 1 + (playerSize - 1) * 0.1f;

        if (size != currentSize)
        {
            sizeText.text = playerSize.ToString();
            // Change size player
            /*sizeText.transform.parent.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.25f);
            transform.DOScale(new Vector3(size, size, size), 0.5f).SetEase(Ease.OutBack);
            currentSize = size;*/
        }
        if (GameManager.Instance.gameWon)
        {
            sizeText.transform.parent.DOScale(Vector3.zero, 0.25f);
        }
        if (GameManager.Instance.gameLost)
        {
            sizeText.transform.parent.DOScale(Vector3.zero, 0.25f);
        }

        yield return null;

    }
}
