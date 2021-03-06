﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
   
    float currentSpeed = 1f;
    GameObject currentTarget;
    Health health;


    private void Awake() {
        FindObjectOfType<LevelController>().AttackersSpawned();
    }

    private void OnDestroy() {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null) {
            levelController.AttackersKilled();
        }
    }

    void Update() {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        if (!currentTarget) {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) {
        if (!currentTarget) { return; }

        health = currentTarget.GetComponent<Health>();
        if (health) {
            health.DealDamage(damage);
        }
    }
}
