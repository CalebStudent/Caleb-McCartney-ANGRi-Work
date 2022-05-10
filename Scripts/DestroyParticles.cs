using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    public float particleDeathTime;

    void Update()
    {
        StartCoroutine(ParticleDestroy(particleDeathTime));
    }

    private IEnumerator ParticleDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
