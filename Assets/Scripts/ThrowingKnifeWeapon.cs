using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeWeapon : WeaponBase
{
    //[SerializeField] float timeToAttack;

    PlayerMove playerMove;
    [SerializeField] GameObject knifePrefab;
    [SerializeField] float spread = 0.5f;
    public static ThrowingKnifeWeapon instance;
    
    private void Awake() {
        playerMove = GetComponentInParent<PlayerMove>();
    }
    
    private void Start() {
        instance = this;
    }

    // private void Update() {
    //     if(timer < timeToAttack){
    //         timer += Time.deltaTime;
    //         return;
    //     }
    //     timer = 0;
    //     Spawnknife();
    // }

    // public void Spawnknife(){
    //     for(int i = 0; i < weaponStats.numberOfAttacks; i++){
    //         GameObject throwingKnife = Instantiate(knifePrefab);
    //         throwingKnife.transform.position = transform.position;
    //         throwingKnife.GetComponent<ThrowingKnifeProjectile>().SetDirection();
    //     }
    // }

    public override void Attack(){
        
        for(int i = 0; i < weaponStats.numberOfAttacks; i++){
            GameObject throwingKnife = Instantiate(knifePrefab);

            Vector3 newKnifePosition = transform.position;
            if(weaponStats.numberOfAttacks > 1){
                newKnifePosition.y -= (spread * weaponStats.numberOfAttacks - 1) / 2; // calculating offset
                newKnifePosition.y += i * spread;// spreading the knives along the line
            }

            throwingKnife.transform.position = newKnifePosition;


            throwingKnife.GetComponent<ThrowingKnifeProjectile>().SetDirection();
        }


    }
}
