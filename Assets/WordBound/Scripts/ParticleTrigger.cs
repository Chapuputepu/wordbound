using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    public ParticleSystem particleSystem;

    // Этот метод будет вызываться Animation Event
    public void PlayParticleSystem()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
        else
        {
            Debug.LogWarning("Particle System is not assigned.");
        }
    }
}