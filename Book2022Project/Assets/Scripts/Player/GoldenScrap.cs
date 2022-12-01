using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenScrap : MonoBehaviour
{
    [SerializeField]
    int _goldenScrapToAdd = 1;
    [SerializeField]
    GameObject _parentGameObject = null;
    private void OnTriggerEnter(Collider other)
    {

        PlayerCollider playerCollider = other.GetComponentInParent<PlayerCollider>();
        RessourceManager ressourcesManager = other.GetComponentInParent<RessourceManager>();

        if (ressourcesManager != null && playerCollider != null)
        {

            if (ressourcesManager.MaxGoldenScrapContainor >= (ressourcesManager.GoldenScrapNumber + _goldenScrapToAdd))
            {
                ressourcesManager.AddGoldenScrap(_goldenScrapToAdd);
                Destroy(_parentGameObject);
            }

            

        }
    }
}
