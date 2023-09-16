using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour{

    private Animator bossAnimator;
    [HideInInspector] public Rigidbody2D bossRigid;
    public Transform playerPosition;

    bool isLookingRight = true;
    private float distancePlayer;

    [Header("Healt")]
    [SerializeField] private float healt;
    [SerializeField] private HealthBar healthBar;

    [Header("Attack")]
    [SerializeField] private Transform attackController;
    [SerializeField] private float attackRadious;
    [SerializeField] private float attackDamage;


    private void Start(){
        bossAnimator = GetComponent<Animator>();
        bossRigid = GetComponent<Rigidbody2D>();
        healthBar.InitializeHealthBar(healt);
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update(){

        distancePlayer = Vector2.Distance(transform.position, playerPosition.position);
        bossAnimator.SetFloat("PlayerDistance", distancePlayer);
    }

    public void TakeDamage(float damage) {

        healt -= damage;

        healthBar.ChangeCurrentHealt(healt);

        if (healt <= 0){
            bossAnimator.SetTrigger("Death");
        }
    }

    void Death(){

        
    }

    public void LookAtPlayer(){

        if((playerPosition.position.x > transform.position.x && !isLookingRight) || (playerPosition.position.x < transform.position.x && isLookingRight)){

            isLookingRight = !isLookingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Attack(){

        Collider2D[] objects = Physics2D.OverlapCircleAll(attackController.position, attackRadious);

        foreach(Collider2D collision in objects){
            if (collision.CompareTag("Player")){
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRadious);
    }
}