using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScrapAttack : BlueprintAttack
{
    [SerializeField]
    ScrapAttackProjectile _scrapAttackProjectile = null;

    [SerializeField]
    int ScrapAttackIndex = 0;
             
    [SerializeField]
    StartTransformProjectile _startProjectileTransform = null;

    [SerializeField]
    public float _maxTimeBeforeAttack = 1.5f;



    private float _currentTimeBeforeAttack = 0;

    private bool _startBeforeAttack = false;

    private RessourceManager _ressourceManager;

    private bool _activeTimer = false;
    
    

    private void Start()
    {
        _ressourceManager = GetComponentInParent<RessourceManager>();
       
    }

    private void Awake()
    {

    }
    private void Update()
    {
        
        if (_activeTimer == true)
        {
            
            if (_currentTimeBeforeAttack < _maxTimeBeforeAttack)
            {
                _currentTimeBeforeAttack += Time.deltaTime;
                
            }

            else
            {
                _currentTimeBeforeAttack = 0;
                _activeTimer = false;
                
            }


        }
    }

    public void CheckIfPlayerCanAttack()
    {

        if (_activeTimer == false)
        {

            //Debug.Log("ATTACK");
            Attack();
            _activeTimer = true;

        }


        

    }

    public override void CheckInputAttackScrap()
    {
        
        CheckIfPlayerCanAttack();
    }
    private void Attack()
    {
        
        ScrapAttackProjectile currentProjectile = Instantiate<ScrapAttackProjectile>(_scrapAttackProjectile);
        currentProjectile.transform.rotation = _startProjectileTransform.transform.rotation;
        currentProjectile.transform.position = _startProjectileTransform.transform.position;
        

    }

    public override void SetBlueprintAttackProperties()
    {
        StartTransformProjectile currentStartTransformProjectile = GameManager._instance.PlayerManager.StartTransformProjectile;
        _startProjectileTransform = currentStartTransformProjectile;
    }

    
}
