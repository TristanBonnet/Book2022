using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    [SerializeField]
    int _scrapsCost = 5;
    [SerializeField]
    Sprite _constructionSprite = null;
    [SerializeField]
    bool _isValid = false;
    [SerializeField]
    int _constructionIndex = 0;

    

    public int ScrapCost => _scrapsCost;

    public Sprite ConstructionSprite => _constructionSprite;

    public bool IsValid => _isValid;

    public int ConstructionIndex => _constructionIndex;

    public void SetConstructionValidity(bool isValid)
    {

        _isValid = isValid;

    }

}
