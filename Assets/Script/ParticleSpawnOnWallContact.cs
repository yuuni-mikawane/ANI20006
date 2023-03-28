using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawnOnWallContact : MonoBehaviour
{
    public int activationCount = 1;
    public GameObject particlePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (activationCount > 0)
        {
            Instantiate(particlePrefab, collision.contacts[0].point, Quaternion.identity);
            activationCount--;
        }
    }
}
