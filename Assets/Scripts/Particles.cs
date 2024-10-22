using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private ParticleSystem _particles;
    private void Start()
    {
        AudioManager.Instance.PlayEffect("Death");
        _particles = GetComponent<ParticleSystem>();
        _particles.Play();
        Destroy(gameObject, _particles.main.duration);
    }
}
