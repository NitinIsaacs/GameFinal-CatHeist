using UnityEngine;

public class DustEffect : MonoBehaviour
{
    public ParticleSystem dustParticles;
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        if (transform.position != previousPosition)
        {
            if (!dustParticles.isPlaying)
            {
                dustParticles.Play();
            }
        }
        else
        {
            if (dustParticles.isPlaying)
            {
                dustParticles.Stop();
            }
        }

        previousPosition = transform.position;
    }
}
