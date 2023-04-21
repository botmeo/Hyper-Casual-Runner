using DG.Tweening;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private AudioSource deathSound;
    private Animator playerAnim;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        int soundOn = PlayerPrefs.GetInt("Sound");
        if (other.CompareTag("PickUp"))
        {
            if (soundOn == 1)
            {
                collectSound.Play();
            }
            GameManager.Instance.playerSize += 1;
            other.GetComponent<Collider>().enabled = false;
            other.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
            {
                other.gameObject.SetActive(false);
            });
        }
        if (other.CompareTag("Block"))
        {
            playerAnim.SetTrigger("kick");
            other.GetComponent<Block>().CheckHit();
        }
        if (other.CompareTag("Gate"))
        {
            other.GetComponent<Gate>().ExecuteOperation();
        }
        if (other.CompareTag("Trap"))
        {
            GameManager.Instance.gameLost = true;
            if (soundOn == 1)
            {
                deathSound.Play();
            }
            GetComponent<Collider>().enabled = false;
        }
        if (other.CompareTag("Finish"))
        {
            if (soundOn == 1)
            {
                winSound.Play();
            }
            GameManager.Instance.gameWon = true;
        }
    }
}
