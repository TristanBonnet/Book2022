using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlueprintAttack : MonoBehaviour
{
    [SerializeField]
     protected int _blueprintAttackIndex = 0;

    [SerializeField]
    protected int _scrapCost = 2;

    

    public int BlueprintAttackIndex => _blueprintAttackIndex;

    public int ScrapCost => _scrapCost;

    public virtual void CheckInputAttackScrap()
    {
        

    }

    public virtual void SetBlueprintAttackProperties()
    {
           

    }
}
