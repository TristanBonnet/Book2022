using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawn : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particle = null;


    private void Start()
    {
        if (_particle.isPlaying)
        {
            _particle.Play();
        }
    }

    private void Update()
    {
        if (_particle.isPlaying == false)
        {
            Destroy(this.gameObject);
        }
    }
}
