using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour{

    private Animator bossAnimator;
    public Rigidbody2D bossRigid;
    public Transform playerPosition;
    public float moveSpeed = 2.0f;

    [SerializeField] bool isLookingRight = true;
    private float distancePlayer;

    [Header("Healt")]
    [SerializeField] private float healt;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] GameObject winCanvas;

    [Header("Attack")]
    [SerializeField] private Transform attackController;
    [SerializeField] private float attackRadious;
    private Player player;


    private void Start(){

        bossAnimator = GetComponent<Animator>();
        bossRigid = GetComponent<Rigidbody2D>();
        healthBar.InitializeHealthBar(healt);
        healthBar.InitializeHealthBar(healt);
        //playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //player = FindObjectOfType<Player>();

        winCanvas.SetActive(false);
    }

    private void Update(){

        distancePlayer = Vector2.Distance(transform.position, playerPosition.position);
        bossAnimator.SetFloat("PlayerDistance", distancePlayer);
    }

    public void TakeDamage(float damage) {

        healt -= damage;

        healthBar.ChangeCurrentHealt(healt);

        if (healt <= 0){
            Death();
        }
    }

    void Death(){
        winCanvas.SetActive(true);
    }
    
    public void LookAtPlayer(){
        
        if((playerPosition.position.x > transform.position.x && !isLookingRight) || (playerPosition.position.x < transform.position.x && isLookingRight)){

            isLookingRight = !isLookingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Attack(){
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = FindObjectOfType<Player>();
        Collider2D[] objects = Physics2D.OverlapCircleAll(attackController.position, attackRadious);

        foreach(Collider2D collision in objects){
            if (collision.CompareTag("Player")){
                player.DeathByBoss();
            }
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRadious);
    }
}