using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    List<Construction> _constructionList = null;
    [SerializeField]
    private Rigidbody _playerRigibody = null;
    [SerializeField]
    private float _jumpForce = 10000;
    [SerializeField]
    private Transform _startTraceTransform = null;
    [SerializeField]
    private float _YLocation = 5;



    public int _currentIndexList = 0;

    public void ChangeConstructionList(bool increment)
    {
        if (increment)
        {
            _currentIndexList += 1;

            if (_currentIndexList > _constructionList.Count - 1)
            {
                _currentIndexList = 0;
            }
        }

        else
        {
            _currentIndexList -= 1;

            if (_currentIndexList < 0)
            {
                _currentIndexList = _constructionList.Count - 1;
            }
        }


    }

    public Construction GetCurrentConstruction()
    {
        return _constructionList[_currentIndexList];
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

      Construction currentConstructionSpawned =  Instantiate<Construction>(GetCurrentConstruction());
        currentConstructionSpawned.transform.position = platformPosition;
        currentConstructionSpawned.transform.rotation = _startTraceTransform.transform.rotation;

    }
}
