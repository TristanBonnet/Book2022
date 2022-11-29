using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _camera = null;

    [SerializeField]
    private List<Sprite> _spriteList = null;
    [SerializeField]
    private SpriteRenderer _currentSprite = null;

   

    private void Start()
    {
        _camera = GameManager._instance.Camera;
        if (_spriteList[0] != null)
        {
            _currentSprite.sprite = _spriteList[0];
        }
    }

    private void Update()
    {
        if (_camera!= null)
        {
            Quaternion rotation = Quaternion.LookRotation(_camera.transform.position - transform.position, Vector3.up);
            transform.rotation = rotation;
        }
    }

    public void SetSprite(int spriteIndex)

    {
        if (_spriteList[spriteIndex] != null)
        {
            _currentSprite.sprite = _spriteList[spriteIndex];

        }  

    }
}
