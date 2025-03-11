using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    private static Action ADeadTrigger;
    private Animator anim;
    private CharacterController characterController;

    private static bool _isDead;
    public static bool IsDead
    {
        get { return _isDead; }
        set
        {
            _isDead = value;
            ADeadTrigger?.Invoke();
        }
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();    
        characterController = GetComponent<CharacterController>();
        ADeadTrigger += OnDeath;
        _isDead = false;
    }

    private void OnDeath()
    {
        Debug.Log("Dead");
        anim.SetTrigger("isDead");
        characterController.enabled = false;
    }

    private void OnDestroy()
    {
        ADeadTrigger -= OnDeath;
    }
}
