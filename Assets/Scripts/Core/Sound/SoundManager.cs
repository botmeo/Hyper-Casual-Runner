using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public enum SoundState
    {
        Off,
        On
    }

    [SerializeField] private Button vibrateSetting;
    [SerializeField] private Button soundSetting;

    private SoundState vibrateState;
    private SoundState soundState;

    private void Start()
    {
        vibrateState = (SoundState)PlayerPrefs.GetInt("Vibrate", 1);
        soundState = (SoundState)PlayerPrefs.GetInt("Sound", 1);

        SetButtonColor(vibrateSetting, vibrateState);
        SetButtonColor(soundSetting, soundState);
    }

    public void VibrateSetting()
    {
        vibrateState = (SoundState)(((int)vibrateState + 1) % 2);
        PlayerPrefs.SetInt("Vibrate", (int)vibrateState);
        SetButtonColor(vibrateSetting, vibrateState);
    }

    public void SoundSetting()
    {
        soundState = (SoundState)(((int)soundState + 1) % 2);
        PlayerPrefs.SetInt("Sound", (int)soundState);
        SetButtonColor(soundSetting, soundState);
    }

    private void SetButtonColor(Button button, SoundState state)
    {
        Color32 color = state == SoundState.On ? new Color32(255, 255, 255, 255) : new Color32(103, 103, 103, 255);
        button.image.color = color;
    }
}
