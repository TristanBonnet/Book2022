using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintManager : MonoBehaviour
{
    [SerializeField]
    private List<Construction> _constructionList = null;

    [SerializeField]
    private List<BlueprintAttack> _attackList = null;

    public List<Construction> ConstructionList => _constructionList;

    public List<BlueprintAttack> AttackList => _attackList;
}
