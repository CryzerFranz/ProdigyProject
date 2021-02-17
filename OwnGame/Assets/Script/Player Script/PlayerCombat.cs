using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCombat : MonoBehaviour
{
    static public PlayerCombat instance;
    private void Awake()
    {
        instance = this;    
    }

    Animator animator;

    private NavMeshAgent playerNavMesh;
    private Movement playerMovement;

    public AbilityTImeBar abilityTimeBar;

    private GameObject weapon;
    private float attackRange = 0f;
    
    [SerializeField]
    private LayerMask enemyLayers;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerNavMesh = GetComponent<NavMeshAgent>();
        playerMovement = GetComponent<Movement>();

    }

    void Update()
    {
        if (InputManager.instance.GetKeyDown(KeybindingActions.ability_01))
        {
            animator.SetFloat("Forward", 0);
            attackRange = 2f;
            executeAbility("Ability_01");
        }
    }
    void executeAbility(string abilityName)
    {
        animator.SetTrigger(abilityName);
        //abilityTimeBar.SetMaxValue(animator.runtimeAnimatorController.animationClips
        playerMovement.enabled = false;
        playerNavMesh.ResetPath();
    }
    //void Attack()
    //{
    //    animator.SetTrigger("Ability_01");
    //    playerMovement.enabled = false;
    //    playerNavMesh.ResetPath();
    //    //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    //}

    public void hitEnemies(Collider other, float damageValue)
    {
            Debug.Log(other.name);
            other.GetComponent<BasicEnemyStats>().takeDamage(damageValue);
    }
}
