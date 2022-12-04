using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField]
    AudioClip _audioclip = null;
    private void OnTriggerEnter(Collider other)
    {

        RessourceManager ressourcesManager = other.GetComponentInParent<RessourceManager>();

        if (ressourcesManager != null)
        {

            ressourcesManager.AddRing(1);
            SoundScript soundscript = Instantiate<SoundScript>(GameManager._instance.SoundScript);
            soundscript.SetAudioClip(_audioclip);
            soundscript.transform.position = transform.position;
            Destroy(gameObject);

        }
    }
}
