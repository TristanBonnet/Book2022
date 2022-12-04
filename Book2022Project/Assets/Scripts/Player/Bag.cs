using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField]
    private int _goldenScrapsNecessary = 5;
    [SerializeField]
    private int _slotsToAdd = 15;
    [SerializeField]
    AudioClip _audioclip = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerManager playerManager = other.GetComponentInParent<PlayerManager>();
        RessourceManager ressourcesManager = other.GetComponentInParent<RessourceManager>();

        if (playerManager && ressourcesManager != null)
        {

            if (ressourcesManager.GoldenScrapNumber >= _goldenScrapsNecessary)
            {
                SoundScript soundscript = Instantiate<SoundScript>(GameManager._instance.SoundScript);
                soundscript.SetAudioClip(_audioclip);
                soundscript.transform.position = transform.position;
                ressourcesManager.AddScrapContainor(_slotsToAdd);
                Destroy(this.gameObject);

            }
            

        }
    }
}
