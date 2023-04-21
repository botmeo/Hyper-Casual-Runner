using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (GameManager.Instance.gameStarted)
        {
            animator.SetBool("run", GameManager.Instance.gameStarted);
        }
        if (GameManager.Instance.gameWon)
        {
            animator.SetTrigger("win");
        }
        if (GameManager.Instance.gameLost)
        {
            animator.SetTrigger("die");
        }
    }
}
