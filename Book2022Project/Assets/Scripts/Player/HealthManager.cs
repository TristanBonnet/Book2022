using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    int _maxHealthPoint = 4;

    [SerializeField]
    bool _isDead = false;
    [SerializeField]
    UnityEvent _deadEvent = null;

    public int _currentHealthPoint = 0;

    public void AddHealthPoint(int HealthAdded)
    {
        if (_currentHealthPoint < _maxHealthPoint)
        {
            _currentHealthPoint += 1;
        }

        UpdateUIManager();
    }

    public void RemoveHealthPoint(int HealthRemoved, GameObject sender)
    {
        if (_currentHealthPoint > 0)
        {
            _currentHealthPoint -= HealthRemoved;
            

            if (_currentHealthPoint <= 0)
            {
                _currentHealthPoint = 0;
                _isDead = true;
                Debug.Log("REMOVE HEALTH");
                _deadEvent.Invoke();
            }

            else
            {
                _isDead = false;
            }
        }

        //else
        //{
        //    _deadEvent.Invoke();
        //}


        UpdateUIManager();

    }

    public void UpdateUIManager()
    {
        PlayerManager playerManager = GetComponentInParent<PlayerManager>();

        if (playerManager != null)
        {

            GameManager._instance.UIManager.UpdateRingText();
            playerManager.PlayerLocomotion.PlayerRigibody.AddForce(Vector3.up * 1500);

        }


    }
}
