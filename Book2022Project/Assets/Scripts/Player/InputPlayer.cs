using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    PlayerControls _playerControls;
    [SerializeField]
    PlayerLocomotion _playerLocomotion = null;
    [SerializeField]
    ClassicAttack _playerClassicAttack = null;
    [SerializeField]
    PlatformManager _playerPlatformManager = null;
    [SerializeField]
    SpinAttack _spinAttackComponent = null;
    

    public Vector2 _movementInput;
    public Vector2 _cameraInput;
    public float _verticalInput;
    public float _horizontalInput;

    public float _cameraInputX;
    public float _cameraInputY;

    public bool _jump;
    public bool _classicAttackActive = false;
    public bool _incrementConstructionIndex = false;
    public bool _incrementAttackIndex = false;
    public bool _construct = false;
    public bool _blueprintAttack = false;
    public bool _spinAttack = false;


    private float _moveAmount;
    
    private void OnEnable()
    {
        if (_playerControls ==  null)
        {
            _playerControls = new PlayerControls();

            _playerControls.PlayerMovements.Movements.performed += i => _movementInput =  i.ReadValue<Vector2>();
            _playerControls.PlayerMovements.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
            _playerControls.PlayerMovements.Jump.performed += i => _jump = true;
            _playerControls.PlayerMovements.Attack.performed += i => _classicAttackActive = true;
            _playerControls.PlayerMovements.IncrementConstructionIndex.performed += i => _incrementConstructionIndex = true;
            _playerControls.PlayerMovements.IncrementAttackIndex.performed += i => _incrementAttackIndex = true;
            _playerControls.PlayerMovements.Construct.performed += i => _construct = true;
            _playerControls.PlayerMovements.BlueprintAttack.performed += i => _blueprintAttack = true;
            _playerControls.PlayerMovements.SpinAttack.performed += i => _spinAttack = true;


        }

        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();

    }

    private void HandleMovementInputs()
    {

        _verticalInput = _movementInput.y;
        _horizontalInput = _movementInput.x;

        _cameraInputY = _cameraInput.y;
        _cameraInputX = _cameraInput.x;

    }

    public void HandleAllInputs()
    {

        HandleMovementInputs();
        HandleJumpInput();
        HandleClassicAttackInput();
        HandleConstructionInputs();
        HandleSpinAttackInput();
        

    }

    private void HandleJumpInput()
    {
        if (_jump)
        {
            _jump = false;
            _playerLocomotion.JumpInput();

        }

    }

    private void HandleClassicAttackInput()
    {
        if (_classicAttackActive == true)
        {

            _classicAttackActive = false;
            _playerClassicAttack.StartAttack();

        }


    }

    private void HandleSpinAttackInput()
    {
        if (_spinAttack == true)
        {
            _spinAttack = false;
            _spinAttackComponent.SetSpinAttackActivated(true);
        }


    }

    private void HandleIncrementConstructionIndex()
    {

        if (_incrementConstructionIndex)
        {
            _incrementConstructionIndex = false;
            _playerPlatformManager.ChangeConstructionList();
            
        }



    }

    private void HandleIncrementAttackIndex()
    {
        if (_incrementAttackIndex)
        {
            _incrementAttackIndex = false;
            _playerPlatformManager.ChangeAttackList();

        }


    }

    private void HandleConstruct()
    {
        if (_construct)
        {
            _construct = false;
            _playerPlatformManager.CheckConstructionCost();
        }


    }

    private void HandleBlueprintAttack()
    {
        
        if (_blueprintAttack)
        {
            
            _blueprintAttack = false;
            _playerPlatformManager.CheckAttackCost();
            
        }


    }

    private void HandleConstructionInputs()
    {
        HandleIncrementConstructionIndex();
        HandleIncrementAttackIndex();
        HandleConstruct();
        HandleBlueprintAttack();

    }
}
