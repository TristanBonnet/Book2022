using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour
{
    [SerializeField]
    int _goldenScrapNecessary = 0;
    [SerializeField]
    int _wrenchToAdd = 1;
    [SerializeField]
    GameObject _parentGameObject = null;
    [SerializeField]
    AudioClip _audioclip = null;
    private void OnTriggerEnter(Collider other)
    {
       
        RessourceManager ressourcesManager = other.GetComponentInParent<RessourceManager>();
        PlayerCollider playerCollider = other.GetComponentInParent<PlayerCollider>();
        if (ressourcesManager != null && playerCollider != null)
        {
            if (ressourcesManager.GoldenScrapNumber >= _goldenScrapNecessary)
            {
                SoundScript soundscript = Instantiate<SoundScript>(GameManager._instance.SoundScript);
                soundscript.SetAudioClip(_audioclip);
                soundscript.transform.position = transform.position;
                ressourcesManager.AddWrench(_wrenchToAdd);
                Destroy(_parentGameObject);
            }
            
            

        }
    }
}
