using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        RessourceManager ressourcesManager = other.GetComponentInParent<RessourceManager>();

        if (ressourcesManager != null)
        {

            ressourcesManager.AddScrap(1);
            Destroy(gameObject);

        }
    }
}
