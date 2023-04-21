using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float limitX;
    [SerializeField] private float sidewaySpeed;

    private float finalPosition;
    private float currentPosition;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (GameManager.Instance.gameStarted && !GameManager.Instance.gameLost && !GameManager.Instance.gameWon)
            {
                PLayerMovement();
            }
        }
    }

    private void PLayerMovement()
    {
        float percentageX = (Input.mousePosition.x - Screen.width / 2) / (Screen.width * 0.5f) * 2;
        percentageX = Mathf.Clamp(percentageX, -1.0f, 1.0f);
        finalPosition = percentageX * limitX;

        float delta = finalPosition - currentPosition;
        currentPosition += (delta * Time.deltaTime * sidewaySpeed);
        currentPosition = Mathf.Clamp(currentPosition, -limitX, limitX);
        player.localPosition = new Vector3(currentPosition, 0, 0);
    }
}
