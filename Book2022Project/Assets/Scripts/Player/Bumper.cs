using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : Construction
{
    [SerializeField]
    private float _bumperForce = 1000;
    [SerializeField]
    private BumperJump _bumperJump = null;
    [SerializeField]
    AudioClip _audioclip = null;

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        Rigidbody playerRigibody = other.GetComponentInParent<Rigidbody>();
        

        if (player != null && playerRigibody != null)
        {
            SoundScript soundscript = Instantiate<SoundScript>(GameManager._instance.SoundScript);
            soundscript.SetAudioClip(_audioclip);
            soundscript.transform.position = transform.position;
            _bumperJump.SetPlayerRigibody(playerRigibody);
            _bumperJump.enabled = true;
            

        }
    }
}
