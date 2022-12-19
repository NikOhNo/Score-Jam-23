using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
