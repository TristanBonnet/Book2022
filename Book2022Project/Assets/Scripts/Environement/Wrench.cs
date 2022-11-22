using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        RessourceManager ressourcesManager = other.GetComponentInParent<RessourceManager>();

        if (ressourcesManager != null)
        {

            ressourcesManager.AddWrench(1);
            Destroy(gameObject);

        }
    }
}
