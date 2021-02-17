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

    private Animator animator;

    private NavMeshAgent playerNavMesh;
    private Movement playerMovement;

    public AbilityTImeBar abilityTimeBar;

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
            executeAbility("Ability_01");
        }
    }
    void executeAbility(string abilityName)
    {
        animator.SetTrigger(abilityName);
       // abilityTimeBar.SetMaxValue();
        playerMovement.enabled = false;
        playerNavMesh.ResetPath();
    }
    

    public void hitEnemies(Collider other, float damageValue)
    {
            Debug.Log(other.name);
            other.GetComponent<BasicEnemyStats>().takeDamage(damageValue);
    }
}
