using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    [SerializeField]
    int _scrapToAdd = 1;
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
            if (ressourcesManager.MaxScrapContainor >= (ressourcesManager.ScrapNumber + _scrapToAdd))
            {
                ressourcesManager.AddScrap(_scrapToAdd);
                SoundScript soundscript = Instantiate<SoundScript>(GameManager._instance.SoundScript);
                soundscript.SetAudioClip(_audioclip);
                soundscript.transform.position = transform.position;
                Destroy(_parentGameObject);

            }


        }
    }
}
