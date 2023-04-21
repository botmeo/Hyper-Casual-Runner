using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Size & Color")]
    [SerializeField] private int startingSize;
    [SerializeField] private Material[] blockColor;
    [SerializeField] private MeshRenderer blockMesh;

    [Header("References")]
    [SerializeField] private GameObject completeBlock;
    [SerializeField] private GameObject brokenBlock;
    [SerializeField] private TextMeshPro blockSizeText;

    [Header("SoundEffect")]
    [SerializeField] private AudioSource breakSound;
    [SerializeField] private AudioSource deathSound;

    private void Start()
    {
        completeBlock.SetActive(true);
        brokenBlock.SetActive(false);
        blockSizeText.text = startingSize.ToString();
        RandomColor();
    }

    private void RandomColor()
    {
        int colorIndex = (startingSize - 1) / 3;
        colorIndex = Mathf.Clamp(colorIndex, 0, blockColor.Length - 1);
        blockMesh.material = blockColor[colorIndex];
    }

    public void CheckHit()
    {
        int vibrateOn = PlayerPrefs.GetInt("Vibrate");
        int soundOn = PlayerPrefs.GetInt("Sound");
        if (vibrateOn == 1)
        {
            Handheld.Vibrate();
        }

        if (GameManager.Instance.playerSize > startingSize)
        {
            ParticleManager.Instance.PlayParticle(0, transform.position);
            GameManager.Instance.playerSize -= startingSize;
            completeBlock.SetActive(false);
            brokenBlock.SetActive(true);
            foreach (Transform childTransform in brokenBlock.transform)
            {
                Renderer childRenderer = childTransform.GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    childRenderer.material = blockMesh.material;
                }
            }
            blockSizeText.gameObject.SetActive(false);
            if (soundOn == 1)
            {
                breakSound.Play();
            }
        }
        else
        {
            if (soundOn == 1)
            {
                deathSound.Play();
            }
            GameManager.Instance.gameLost = true;
        }
    }
}
