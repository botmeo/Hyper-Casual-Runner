using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private static ParticleManager instance;
    public static ParticleManager Instance { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    public void PlayParticle(int index, Vector3 position)
    {
        ParticleSystem part = transform.GetChild(index).GetComponent<ParticleSystem>();
        transform.GetChild(index).position = position;
        part.Clear();
        part.Play();
    }
}
