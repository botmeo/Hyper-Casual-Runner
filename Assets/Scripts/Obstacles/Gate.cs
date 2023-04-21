using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private enum OperationType
    {
        Addition,
        Difference,
        Multiplication,
        Division
    }

    [Header("Operation")]
    [SerializeField] private OperationType gateOperation;
    [SerializeField] private int value;

    [Header("References")]
    [SerializeField] private TextMeshPro operationText;
    [SerializeField] private MeshRenderer forceField;
    [SerializeField] private Material[] operationTypeMaterial;

    [Header("SoundEffect")]
    [SerializeField] private AudioSource positiveSound;
    [SerializeField] private AudioSource negativeSound;

    private string finalText = "";

    private void Start()
    {
        RandomOperation();
    }

    private void RandomOperation()
    {
        if (gateOperation == OperationType.Addition)
        {
            finalText += "+";
        }
        if (gateOperation == OperationType.Difference)
        {
            finalText += "-";
        }
        if (gateOperation == OperationType.Multiplication)
        {
            finalText += "x";
        }
        if (gateOperation == OperationType.Division)
        {
            finalText += "÷";
        }
        finalText += value.ToString();
        operationText.text = finalText;

        if (gateOperation == OperationType.Addition || gateOperation == OperationType.Multiplication)
        {
            forceField.material = operationTypeMaterial[0];
        }
        else
        {
            forceField.material = operationTypeMaterial[1];
        }
    }

    public void ExecuteOperation()
    {
        int soundOn = PlayerPrefs.GetInt("Sound");
        if (gateOperation == OperationType.Addition)
        {
            if (soundOn == 1)
            {
                positiveSound.Play();
            }
            GameManager.Instance.playerSize += value;
        }
        if (gateOperation == OperationType.Difference)
        {
            if (soundOn == 1)
            {
                negativeSound.Play();
            }
            GameManager.Instance.playerSize -= value;
        }
        if (gateOperation == OperationType.Multiplication)
        {
            if (soundOn == 1)
            {
                positiveSound.Play();
            }
            GameManager.Instance.playerSize *= value;
        }
        if (gateOperation == OperationType.Division)
        {
            if (soundOn == 1)
            {
                negativeSound.Play();
            }
            GameManager.Instance.playerSize /= value;
        }

        GetComponent<BoxCollider>().enabled = false;
        forceField.gameObject.SetActive(false);
    }
}
