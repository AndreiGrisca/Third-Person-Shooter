using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.TextCore;

public class  Enemy: MonoBehaviour
{
    [SerializeField] private Transform positionTarnasform;
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform[] patrulPoint;
    [SerializeField] private Vector2 waitTame;
    [SerializeField] private int currentHealth,maxHealth;
    private FieldOfView fieldOfView;
    public HealthBar healthBar;
    public  float curentTime;
    private int _curentIndex;   
    private Vector3 target;
    private bool _waiting,isDead=true;
    private bool trigger;
    private Animator _animator;
    
    
    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        fieldOfView = GetComponent<FieldOfView>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = 100;
        _waiting = true;
        DetectedPatroll();
        
    }

    private void Update()
    {
        if (isDead)
        {
             _animator.SetFloat("MoveSpeed", enemy.velocity.magnitude);
             PatrulingAi();
             AttackAi();
             DamgePlayer();
        }
       

    }
    private void PatrulingAi()
    {
        if (Vector3.Distance(transform.position, target) < 0.2f&&_waiting==false)
        {
           transform.LookAt(target); 
            enemy.speed = 0;
            _waiting = true;
            curentTime = Random.Range(waitTame.x, waitTame.y);
        }
        else if (_waiting)
        {
            Waiting();
        }
    }

    private void AttackAi()
    {
        if ( fieldOfView.canSeePlayer )
        {
            enemy.SetDestination(positionTarnasform.position);
        }
        
        else 
        {
            DetectedPatroll();
        }
    }
    private void DetectedPatroll()
        {
            enemy.speed = 1;
            target = patrulPoint[_curentIndex].position;
            enemy.SetDestination(target);
        }

        private void Waiting()
        {
            curentTime -= Time.deltaTime;
            
            if (curentTime <= 0)
            {
                
                _curentIndex++;
                if (_curentIndex == patrulPoint.Length)
                {
                    _curentIndex = 0; 
                }
                DetectedPatroll();
                _waiting = false;
            }
        }

        private void DamgePlayer()
        {
            if ( Vector3.Distance(transform.position,positionTarnasform .position)<0.8f)
            {
                transform.LookAt(positionTarnasform);
                enemy.speed = 0;
                _animator.SetBool("Attack", true);
            }
            else
            {
                enemy.speed = 1;
            }
        }

        public void TakeDamage(int damage)
        {
         
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
        
                if (currentHealth <=0 && isDead==true)
                {
                    isDead = false;
                    EnemyDie();
                }
            }
        }
        private void EnemyDie()
        {
            GameManager.gameManager.IncreaseScore();
            
            enemy.speed = 0;
            _animator.SetBool("Dead", true);
            
            Destroy(gameObject, 3f);
        }
       
        
}