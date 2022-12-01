using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    List<Construction> _constructionList = null;
    [SerializeField]
    List<BlueprintAttack> _attackList = null;
    [SerializeField]
    private Rigidbody _playerRigibody = null;
    [SerializeField]
    private float _jumpForce = 10000;
    [SerializeField]
    private Transform _startTraceTransform = null;
    [SerializeField]
    private float _YLocation = 5;
    [SerializeField]
    RessourceManager _ressourceManager = null;
    [SerializeField]
    List<bool> _activeConstructionList;

    private Construction _currentPlateform = null;

    private Construction _currentSelectedPlatform = null;

    private BlueprintAttack _currentSelectedAttack = null;

    public int _currentIndexConstructionList = 0;
    public int _currentIndexAttackList = 0;


    private void Start()
    {
        
        UpdateUISelectedPlatform();
        UpdateUISelectedAttack();

        if (_constructionList.Count > 0 && _constructionList[0] != null)
        {
            _currentSelectedPlatform = _constructionList[0];
        }

        if (_attackList.Count > 0 && _attackList[0] != null)
        {
            _currentSelectedAttack = _attackList[0];
            SetBlueprintAttackProperties();
        }

        
    }
    public void ChangeConstructionList()
    {

        if (_constructionList.Count > 0)
        {
            _currentIndexConstructionList += 1;

            if (_currentIndexConstructionList > _constructionList.Count - 1)
            {
                _currentIndexConstructionList = 0;
            }



            _currentSelectedPlatform = _constructionList[_currentIndexConstructionList];

            if (_currentSelectedPlatform != null)
            {
                UpdateUISelectedPlatform();
            }

        }


        GameManager._instance.UIManager.SetBottomTriggerOn(true);

    }

    public void ChangeAttackList()
    {
        Debug.Log("CHANGE ATTACK INDEX");
        if (_attackList.Count > 0)
        {
            _currentIndexAttackList += 1;

            if (_currentIndexAttackList > _attackList.Count - 1)
            {
                _currentIndexAttackList = 0;
            }



            _currentSelectedAttack =  _attackList[_currentIndexAttackList];

            if (_currentSelectedAttack != null)
            {
                
                UpdateUISelectedAttack();
            }

        }


        GameManager._instance.UIManager.SetBottomTriggerOn(true);

    }

    public Construction GetCurrentConstruction()
    {
        return _currentSelectedPlatform;
    }

    public void ConstructPlatform()
    {
        _playerRigibody.AddForce(Vector3.up * _jumpForce);
        RaycastHit hit;
        Vector3 platformPosition;

        if (Physics.Raycast(_startTraceTransform.position, Vector3.up * -1, out hit, _YLocation))
        {
            platformPosition = hit.point;
        }

        else
        {
            platformPosition = _startTraceTransform.position + Vector3.up * -1 * _YLocation;
        }

        if (_currentPlateform != null)
        {
            Destroy(_currentPlateform.gameObject);
        }
        Construction currentConstructionSelected = GetCurrentConstruction();

        if (currentConstructionSelected != null)
        {
            Construction currentConstructionSpawned = Instantiate<Construction>(currentConstructionSelected);
            currentConstructionSpawned.transform.position = platformPosition;
            currentConstructionSpawned.transform.rotation = _startTraceTransform.transform.rotation;
            _currentPlateform = currentConstructionSpawned;
        }
       
        
    }

    public void Attack()
    {

        _currentSelectedAttack.CheckInputAttackScrap();
        Debug.Log(_currentSelectedAttack);

    }

    public void CheckConstructionCost()
    {
        if (_constructionList.Count > 0) 
        {
            if (_ressourceManager.ScrapNumber >= _constructionList[_currentIndexConstructionList].ScrapCost)
            {

                ConstructPlatform();
                _ressourceManager.RemoveScrap(_constructionList[_currentIndexConstructionList].ScrapCost);

            }
        }

        GameManager._instance.UIManager.SetBottomTriggerOn(true);
    }
    public void CheckAttackCost()
    {
        
        if (_attackList.Count > 0)
        {
            if (_ressourceManager.ScrapNumber >= _attackList[_currentIndexAttackList].ScrapCost)
            {
                
                 Attack();
                _ressourceManager.RemoveScrap(_attackList[_currentIndexAttackList].ScrapCost);

            }
        }

        GameManager._instance.UIManager.SetBottomTriggerOn(true);
    }



    private void UpdateUISelectedPlatform()
    {
        if (_currentSelectedPlatform != null)
        {
            GameManager._instance.UIManager.UpdateConstructionPicture(_currentSelectedPlatform.ConstructionSprite);
        }

        else
        {
            GameManager._instance.UIManager.ResetConstructionSprite();
        }

        GameManager._instance.UIManager.SetBottomTriggerOn(true);
    }

    private void UpdateUISelectedAttack()
    {
        if (_currentSelectedAttack != null)
        {
            // ADD UPDATE ATATCK PICTURE IN UI MANAGER
            
        }

        else
        {
            GameManager._instance.UIManager.ResetAttackSprite();
        }

        GameManager._instance.UIManager.SetBottomTriggerOn(true);
    }

    public bool AddConstructionToList(int constructionIndex)
    {
        Construction currentConstructionAdded = GameManager._instance.Blueprint.ConstructionList[constructionIndex];

        if (CheckIfConstructionIsAlreadyActivated(currentConstructionAdded) == false)
        {
            _constructionList.Add(currentConstructionAdded);
            _currentSelectedPlatform = _constructionList[_constructionList.Count - 1];
            _currentIndexConstructionList = _constructionList.Count - 1;
            UpdateUISelectedPlatform();

            return true;
        }

        return false;
    }

    

    public bool AddAttackToList(int attackIndex)
    {
        BlueprintAttack currentAttackAdded = GameManager._instance.Blueprint.AttackList[attackIndex];

        if (CheckIfAttackIsAlreadyActivated(currentAttackAdded) == false)
        {
            
            _attackList.Add(currentAttackAdded);
            currentAttackAdded.SetBlueprintAttackProperties();
            _currentSelectedAttack = _attackList[_attackList.Count - 1];
            _currentIndexAttackList = _attackList.Count - 1;
            UpdateUISelectedAttack();

            return true;
        }

        return false;
    }


    private bool CheckIfConstructionIsAlreadyActivated(Construction constructionAdded)
    {
        for (int i = 0; i < _constructionList.Count; i++)
        {
            if (_constructionList[i].ConstructionIndex == constructionAdded.ConstructionIndex)
            {

                return true;
            }
            
        }

        return false;

    }

    private bool CheckIfAttackIsAlreadyActivated(BlueprintAttack attackAdded)
    {
        for (int i = 0; i < _attackList.Count ; i++)
        {
            if (_attackList[i].BlueprintAttackIndex == attackAdded.BlueprintAttackIndex)
            {

                return true;
            }

        }

        return false;

    }

    private void SetBlueprintAttackProperties()
    {
        for (int i = 0; i < _attackList.Count; i++)
        {
            _attackList[i].SetBlueprintAttackProperties();
        }


    }
}
