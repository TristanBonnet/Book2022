using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintActivation : MonoBehaviour
{
    [SerializeField]
    BlueprintType _blueprintType = BlueprintType.Construction;

    [SerializeField]
    AudioClip _audioclip = null;

    [SerializeField]
    int _blueprintActivationIndex = 0;



    public enum BlueprintType
    {
        Construction,
        Attack,

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        PlatformManager platformManager = other.GetComponentInParent<PlatformManager>();
        PlayerCollider playerCollider = other.GetComponentInParent<PlayerCollider>();

        if (player != null && platformManager != null && playerCollider != null)
        {

            switch (_blueprintType)
            {
                case BlueprintType.Construction:
                    {
                        if (platformManager.AddConstructionToList(_blueprintActivationIndex))
                        {

                            SoundScript soundscript = Instantiate<SoundScript>(GameManager._instance.SoundScript);
                            soundscript.SetAudioClip(_audioclip);
                            soundscript.transform.position = transform.position;
                            Destroy(gameObject);
                        }

                    }
                    break;
                case BlueprintType.Attack:
                    {
                        if (platformManager.AddAttackToList(_blueprintActivationIndex))
                        {
                            SoundScript soundscript = Instantiate<SoundScript>(GameManager._instance.SoundScript);
                            soundscript.SetAudioClip(_audioclip);
                            soundscript.transform.position = transform.position;
                            Destroy(gameObject);
                        }

                    }
                    break;
                default:
                    break;
            }
            

        }
    }
}
