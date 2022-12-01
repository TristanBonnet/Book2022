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
    private void OnTriggerEnter(Collider other)
    {
       
        RessourceManager ressourcesManager = other.GetComponentInParent<RessourceManager>();
        PlayerCollider playerCollider = other.GetComponentInParent<PlayerCollider>();
        if (ressourcesManager != null && playerCollider != null)
        {
            if (ressourcesManager.GoldenScrapNumber >= _goldenScrapNecessary)
            {

                ressourcesManager.AddWrench(_wrenchToAdd);
                Destroy(_parentGameObject);
            }
            
            

        }
    }
}
