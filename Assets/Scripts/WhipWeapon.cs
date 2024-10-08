using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMove playerMove;

    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);
 

    public static WhipWeapon instance;

    private void Awake() {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void Start() {
        instance = this;
    }


    private void ApplyDamage(Collider2D[] colliders){
        for(int i = 0; i < colliders.Length; i++){
            //Debug.Log(colliders[i].gameObject.name);
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if(e != null){
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);
            }
        }
    }

    public override void Attack()
    {
        //StartCoroutine(AttackProcess()); // discharge this attack pattern
        //Debug.Log("Attack!");
        if(playerMove.lastHorizontalVector > 0){
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }else{
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    // IEnumerator AttackProcess(){
    //     for(int i = 0; i < weaponStats.numberOfAttacks; i++){

    //         if(playerMove.lastHorizontalVector > 0){
    //             rightWhipObject.SetActive(true);
    //             Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, attackSize, 0f);
    //             ApplyDamage(colliders);
    //         }else{
    //             leftWhipObject.SetActive(true);
    //             Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, attackSize, 0f);
    //             ApplyDamage(colliders);
    //         }
    //     }
    //     yield return new WaitForSeconds(0.3f);

    // }

    // public void WhipAttack()
    // {aaw
    //     //Debug.Log("Attack!");

    //     if(playerMove.lastHorizontalVector > 0){
    //         rightWhipObject.SetActive(true);
    //         Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, attackSize, 0f);
    //         ApplyDamage(colliders);
    //     }else{
    //         leftWhipObject.SetActive(true);
    //         Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, attackSize, 0f);
    //         ApplyDamage(colliders);
    //     }
    // }
}
