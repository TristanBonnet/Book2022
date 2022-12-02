using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private bool _movableEnemy = false ;

    [SerializeField]
    private List<PathPoint> _pathPointList = null;

    [SerializeField]
    float _pathPointDistanceRange = 0.2f;

    [SerializeField]
    float _enemyWalkSpeed = 1;
    [SerializeField]
    float _enemyRunSpeed = 1;

    [SerializeField]
    AISensor _aiSensor = null;
    [SerializeField]
    RessourcesSpawner _ressourcesSpawner = null;
    [SerializeField]
    SeePlayer _seePlayer = null;
    [SerializeField]
    UnityEvent _event = null;
    [SerializeField]
    Animator _enemyAnimator = null;
    [SerializeField]
    Billboard _enemyBillboard = null;
    [SerializeField]
    float _maxStunTime = 2;
    [SerializeField]
    ParticleSystem _deadParticle = null;

    private bool stun = false;




    private float _currentStunTime = 0;
    private Rigidbody _enemyRigibody = null;
    private PathPoint _currentPathPoint = null;
    private float _currentWaitingTime = 0;
    public int _currentPathPointIndex = 0;
    private bool isDead = false;
    public EnemyState _enemyState = EnemyState.Patrol;
    public PatrolSubState _patrolSubState = PatrolSubState.Move;
    public bool Stun => stun;

   public AISensor AISensor => _aiSensor;

    public enum EnemyState 
    {
        Patrol,
        SeePlayer,

    };
   
    public enum PatrolSubState
    {
        Move,
        Wait


    }



    private void Awake()
    {

       _enemyRigibody =  GetComponentInParent<Rigidbody>();    



    }
    private void Start()
    {
        if (_movableEnemy)
        {
            _currentPathPoint = _pathPointList[0];
        }


    }

    private void FixedUpdate()
    {
        if (_enemyAnimator != null)
        {
            _enemyAnimator.SetFloat("Velocity", _enemyRigibody.velocity.magnitude);       
        }

        if (stun == true)
        {
            if (_currentStunTime < _maxStunTime)
            {
                _currentStunTime += Time.deltaTime;
            }

            else
            {
                stun = false;
                _currentStunTime = 0;
                
            }
        }

        if (isDead == false && stun == false)
        {
            switch (_enemyState)
            {
                case EnemyState.Patrol:
                    {
                        if (_movableEnemy)
                        {
                            switch (_patrolSubState)
                            {
                                case PatrolSubState.Move:
                                    {
                                        RotateEnemyToTarget(_currentPathPoint.transform);
                                        MoveToTarget();

                                        if (CheckDistanceWithTarget(_currentPathPoint.transform, _pathPointDistanceRange) == false)
                                        {
                                            _currentWaitingTime = 0;
                                            StopMovement();
                                            SwitchPatrolSubState(PatrolSubState.Wait);

                                        }



                                    }
                                    break;
                                case PatrolSubState.Wait:
                                    {
                                        _currentWaitingTime += Time.deltaTime;

                                        if (_currentWaitingTime >= _currentPathPoint.WaitingTime)
                                        {
                                            _currentWaitingTime = 0;
                                            GetNextPathPoint();
                                            SwitchPatrolSubState(PatrolSubState.Move);

                                        }



                                    }
                                    break;
                                default:
                                    break;
                            }

                            
                            

                        }


                    }
                    break;
                case EnemyState.SeePlayer:
                    {


                        // Move to player
                        if (_seePlayer.enabled == false)
                        {
                            _seePlayer.enabled = true;
                            Debug.Log("SEE PLAYER");
                            _enemyBillboard.gameObject.SetActive(true);
                            _enemyBillboard.SetSprite(0);
                            
                        }
                        //RotateEnemyToTarget(_aiSensor._player.transform);
                        //MoveToTarget();


                    }
                    break;
                default:
                    break;
            }








        }


    }
    public void GetNextPathPoint()
    {
        
        _currentPathPointIndex += 1;

        if (_currentPathPointIndex > _pathPointList.Count - 1)
        {
            _currentPathPointIndex = 0;
        }

        _currentPathPoint = _pathPointList[_currentPathPointIndex];

    }

     public void RotateEnemyToTarget(Transform target)
    {
        Quaternion startRotation = transform.rotation;
        Vector3 targetPosition = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(targetPosition, Vector3.up);
        Quaternion finalRotation = new Quaternion(0, rotation.y, 0, rotation.w);
        
        transform.rotation = Quaternion.Slerp(startRotation, finalRotation, 0.5f);


    }

    public void SwitchEnemyState(EnemyState enemyState)
    {
        _enemyState = enemyState;

        switch (_enemyState)
        {
            case EnemyState.Patrol:
                {


                }
                break;
            case EnemyState.SeePlayer:
                {


                }
                break;
            default:
                break;
        }




    }

    private void SwitchPatrolSubState(PatrolSubState patrolSubState)
    {

        _patrolSubState = patrolSubState;

        switch (_patrolSubState)
        {
            case PatrolSubState.Move:
                {
                    


                }
                break;
            case PatrolSubState.Wait:
                {



                }
                break;
            default:
                break;
        }


    }

    public void MoveToTarget()
    {
        float currentSpeed = 0;

        if (_enemyState == EnemyState.Patrol)
        {
            currentSpeed = _enemyWalkSpeed;
        }

        else
        {
            currentSpeed = _enemyRunSpeed;
        }
        Vector3 enemyVelocity = transform.forward * Time.deltaTime * currentSpeed;
        //enemyVelocity.Normalize();
        enemyVelocity.y = 0;
        _enemyRigibody.velocity = enemyVelocity;
       



    }

    public bool CheckDistanceWithTarget(Transform target, float distanceToCheck)
    {

      float currentDistanceWithTarget =   Vector3.Distance(target.transform.position, transform.position);
      return currentDistanceWithTarget > distanceToCheck;   

    }

    public void StopMovement()

    {
        _enemyRigibody.velocity = Vector3.zero;


    }

    public void SetDeadState()
    {
        Debug.Log("SET DEAD STATE");
        if (isDead == false)
        {
            

            ParticleSystem particle = Instantiate<ParticleSystem>(_deadParticle);
            particle.transform.position = transform.position;
            Destroy(this.gameObject);
            isDead = true;
        }
        
        

    }


    public void StunEnemy()
    {
        stun = true;
        _seePlayer.enabled = false;
        _enemyBillboard.SetSprite(1);
        _enemyAnimator.SetTrigger("Stun");
        if (_enemyState != EnemyState.SeePlayer)
        {
            _enemyState = EnemyState.SeePlayer;
        }



    }
}
