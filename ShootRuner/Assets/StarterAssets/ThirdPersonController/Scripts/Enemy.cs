using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar; 
    private bool onTriger;
    private bool isAlive;
    private bool isDead;
    private bool attackRate;
    private float speed;
    private NavMeshAgent agent;
    private Animator _animator;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); 
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        isAlive = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (onTriger&&isAlive)
        {
            agent.destination = playerTransform.position;
            _animator.SetFloat("Speed1",agent.speed);
        }
        _animator.SetBool("Attack", Vector3.Distance(transform.position, playerTransform.position) < 1f);
        
    }

    private void EnemyDie()
    {
        GameManager.gameManager.IncreaseScore();
        
        isDead = true;
        onTriger = false;
        _animator.SetBool("Die", true);
        isAlive = false;
        Destroy(gameObject, 6f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            speed = 1;
            onTriger = true;
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <=0 && isDead==false)
        {
            EnemyDie();
        }
    }
}
