using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintActivation : MonoBehaviour
{
    [SerializeField]
    BlueprintType _blueprintType = BlueprintType.Construction;

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

        if (player != null && platformManager != null)
        {

            switch (_blueprintType)
            {
                case BlueprintType.Construction:
                    {
                        if (platformManager.AddConstructionToList(_blueprintActivationIndex))
                        {
                            Destroy(gameObject);
                        }

                    }
                    break;
                case BlueprintType.Attack:
                    {
                        if (platformManager.AddAttackToList(_blueprintActivationIndex))
                        {
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
