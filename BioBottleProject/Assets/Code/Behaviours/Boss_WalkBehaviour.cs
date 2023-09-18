using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_WalkBehaviour : StateMachineBehaviour{

    private Boss boss;
    private Rigidbody2D bossRigid;

    [SerializeField] private float movementSpeed;

    // Variable para determinar la dirección del movimiento (-1 para izquierda, 1 para derecha)
    private int movementDirection = 1;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        bossRigid = boss.bossRigid;

        boss.LookAtPlayer();

        // Determinar la dirección del movimiento en función de la posición del jugador
        if (boss.playerPosition.position.x < boss.transform.position.x)
        {
            movementDirection = -1; // Mover hacia la izquierda
        }
        else
        {
            movementDirection = 1; // Mover hacia la derecha
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Establecer la velocidad del jefe en función de la dirección de movimiento
        bossRigid.velocity = new Vector2(movementSpeed * movementDirection, bossRigid.velocity.y);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Detener el movimiento al salir del estado
        bossRigid.velocity = new Vector2(0, bossRigid.velocity.y);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
