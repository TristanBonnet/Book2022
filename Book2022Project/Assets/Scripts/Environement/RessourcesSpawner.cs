using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject _ressource = null;
    [SerializeField]
    private int _ressourceNumber = 1;
    [SerializeField]
    Transform _transformSpawnRessources = null;
        
    public void SpawnRessource()
    {
        Debug.Log(this);
        for (int i = 1; i <= _ressourceNumber; i++)
        {
            
            GameObject currentRessource = Instantiate<GameObject>(_ressource);
            currentRessource.transform.position = _transformSpawnRessources.position;
        }
           
         

    }
}
