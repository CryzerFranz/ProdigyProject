using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    void Awake()
    {
        instance = this;
    }

    public GameObject oPlayer;
    public GameObject respawnPoint;
    public GameObject deathTransition;
    public GameObject userInterface;

    public bool playerFollowTarget = false;

    /////////////////////////////////////////////////////////


}
