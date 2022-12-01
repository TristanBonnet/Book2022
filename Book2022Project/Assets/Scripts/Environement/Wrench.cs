using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour
{
    [SerializeField]
    int _goldenScrapNecessary = 0;
    [SerializeField]
    int _wrenchToAdd = 1;
    private void OnTriggerEnter(Collider other)
    {

        RessourceManager ressourcesManager = other.GetComponentInParent<RessourceManager>();

        if (ressourcesManager != null)
        {
            if (ressourcesManager.GoldenScrapNumber >= _goldenScrapNecessary)
            {
                ressourcesManager.AddWrench(_wrenchToAdd);
                Destroy(this.gameObject);
            }
            
            

        }
    }
}
