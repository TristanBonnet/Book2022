using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : Construction
{
    [SerializeField]
    private float _bumperForce = 1000;

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        

        if (player != null)
        {
            player.PlayerLocomotion.PlayerRigibody.AddForce(Vector3.up * _bumperForce);

        }
    }
}
