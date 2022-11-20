using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    PlayerLocomotion _playerLocomotion = null;
    [SerializeField]
    Transform _transformSphereTrace = null;
    [SerializeField]
    Transform _playerTransform = null;
    [SerializeField]
    LayerMask _layerMask;
    [SerializeField]
    Gravity _gravity = null;
    public GeneralState _currentState;
    private GeneralState _lastState;

    public GroundedSubState _currentGroundedSubState;
    private GroundedSubState _lastGroundedSubState;

    public InAirSubState _currentInAirSubState;
    private InAirSubState _lastInAirSubState;

    private float _lastPlayerPosition;
   
    
   public enum GeneralState
   {
        Grounded,
        InAir,
        none
   };

    public enum GroundedSubState
    {
        Walking,
        Sprinting,
        none


    };

    public enum InAirSubState
    {
        Jumping,
        Falling,
        none

    };

    private void Awake()
    {
        ChangeGroundedSubState(GroundedSubState.Walking);
    }


    private void Update()
    {
         CheckInAirState();
        
        _lastGroundedSubState = _currentGroundedSubState;
        _lastInAirSubState = _currentInAirSubState;
        _lastPlayerPosition = _playerTransform.position.y;



    }

    public void ChangeGeneralState(GeneralState state)
    {
        _currentState = state;
        if (_currentState != _lastState)
        {
            switch (_lastState)
            {
                case GeneralState.Grounded:
                    {

                        
                        ChangeInAirSubState(InAirSubState.none);

                    }
                    break;
                case GeneralState.InAir:
                    {

                        
                        ChangeGroundedSubState(GroundedSubState.none);

                    }
                    break;
                case GeneralState.none:
                    {

                        
                        ChangeInAirSubState(InAirSubState.none);
                        ChangeGroundedSubState(GroundedSubState.none);

                    }
                    break;
                default:
                    break;
            }
        }


        
        


    }

    public void ChangeInAirSubState(InAirSubState inAirSubState)
    {
        if (_currentState != GeneralState.InAir)
        {
            ChangeGeneralState(GeneralState.InAir);
        }
       
        _currentInAirSubState = inAirSubState;

        if (_lastInAirSubState != _currentInAirSubState)
        {
            switch (_lastInAirSubState)
            {
                case InAirSubState.Jumping:
                    {
                        

                    }
                    break;
                case InAirSubState.Falling:
                    {

                        

                    }
                    break;
                case InAirSubState.none:
                    {

                       

                    }
                    break;
                default:
                    break;
            }
        }
        



    }


    public void ChangeGroundedSubState(GroundedSubState groundedSubState)
    {
        if (_currentState != GeneralState.Grounded)
        {
            ChangeGeneralState(GeneralState.Grounded);
        }
        
        _currentGroundedSubState = groundedSubState;

        if (_lastGroundedSubState != _currentGroundedSubState )
        {
            switch (_lastGroundedSubState)
            {
                case GroundedSubState.Walking:
                    {
                        

                    }
                    break;
                case GroundedSubState.Sprinting:
                    {

                       
                    }
                    break;
                case GroundedSubState.none:
                    {

                        
                    }
                    break;
                default:
                    break;
            }
        }
        



    }


    private void CheckInAirState()
    {
       
        
        

    }

    private void CheckInAirSubState()
    {

        if (_currentState == GeneralState.InAir)
        {
          
            if (_lastPlayerPosition > _playerTransform.position.y)
            {
                float playerPosition = _lastPlayerPosition - _playerTransform.position.y;
                if (playerPosition > 0.2)
                {
                    ChangeInAirSubState(InAirSubState.Jumping);
                }
                
            }

            else
            {
                float playerPosition = _playerTransform.position.y - _lastPlayerPosition ;
                if (playerPosition > 0.2)
                {
                    ChangeInAirSubState(InAirSubState.Falling);
                }
                
            }

            

        }

    }

    
}
