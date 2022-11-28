using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenScrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        RessourceManager ressourcesManager = other.GetComponentInParent<RessourceManager>();

        if (ressourcesManager != null)
        {

            ressourcesManager.AddGoldenScrap(1);
            Destroy(gameObject);

        }
    }
}
