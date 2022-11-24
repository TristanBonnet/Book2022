using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject _ressource = null;
    [SerializeField]
    private int _ressourceNumber = 1;
        
    public void SpawnRessource()
    {
        for (int i = 1; i < _ressourceNumber; i++)
        {
            GameObject currentRessource = Instantiate<GameObject>(_ressource);
            currentRessource.transform.position = transform.position;
        }
            
        
         

    }
}
