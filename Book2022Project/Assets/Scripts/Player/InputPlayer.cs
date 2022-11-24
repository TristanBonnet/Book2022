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
    

    public Vector2 _movementInput;
    public Vector2 _cameraInput;
    public float _verticalInput;
    public float _horizontalInput;

    public float _cameraInputX;
    public float _cameraInputY;

    public bool _jump;
    public bool _classicAttackActive = false;
    public bool _incrementConstructionIndex = false;
    public bool _decrementConstructionIndex = false;
    public bool _construct = false;


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
            _playerControls.PlayerMovements.DecrementConstructionIndex.performed += i => _decrementConstructionIndex = true;
            _playerControls.PlayerMovements.Construct.performed += i => _construct = true;


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

    private void HandleIncrementConstructionIndex()
    {

        if (_incrementConstructionIndex)
        {
            _incrementConstructionIndex = false;
            _playerPlatformManager.ChangeConstructionList(true);
            
        }



    }

    private void HandleDecrementConstructionIndex()
    {
        if (_decrementConstructionIndex)
        {
            _decrementConstructionIndex = false;
            _playerPlatformManager.ChangeConstructionList(false);
        }

    }

    private void HandleConstruct()
    {
        if (_construct)
        {
            _construct = false;
            _playerPlatformManager.ConstructPlatform();
        }


    }

    private void HandleConstructionInputs()
    {
        HandleIncrementConstructionIndex();
        HandleDecrementConstructionIndex();
        HandleConstruct();

    }
}
