using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        RessourceManager ressourcesManager = other.GetComponentInParent<RessourceManager>();

        if (ressourcesManager != null)
        {

            ressourcesManager.AddRing(1);
            Destroy(gameObject);

        }
    }
}
