using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 minPosition;
    [SerializeField] private Vector3 maxPosition;
    [SerializeField] private Vector3 winPosition;
    private float progress;

    private void Update()
    {
        CameraZoom();
    }

    private void CameraZoom()
    {
        float playerSize = GameManager.Instance.playerSize;

        if (!GameManager.Instance.gameWon && !GameManager.Instance.gameLost)
        {
            /* float progress = (float)(playerSize - 1) / 40;*/
            Vector3 currentPos = Vector3.Lerp(minPosition, maxPosition, 0);
            transform.DOLocalMove(currentPos, 1);
        }

        if (GameManager.Instance.gameWon)
        {
            transform.DOLocalMove(winPosition, 1).SetDelay(1.65f);
        }
    }
}
