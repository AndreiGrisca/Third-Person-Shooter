using UnityEngine;
using UnityEngine.AI;


public class AiNavMesh : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar; 
    private bool onTriger;
    private bool isDied;
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
        isDied = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (onTriger&&isDied)
        {
            agent.destination = playerTransform.position;
            _animator.SetFloat("Speed1",agent.speed);
        }

        if (Vector3.Distance(transform.position,playerTransform.position)<1f)
          { 
              _animator.SetBool("Attack",true);
            
          }
        else
          {
              _animator.SetBool("Attack",false);
          }

          if (currentHealth <=0)
          {
              onTriger = false;
              _animator.SetBool("Die", true);
              isDied = false;
              Destroy(gameObject,6f);
            
          }
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
    }
}
