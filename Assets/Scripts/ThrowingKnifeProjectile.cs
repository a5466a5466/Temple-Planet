using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeProjectile : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 knifeDirection;
    [SerializeField] float speed;
    [SerializeField] int damage = 5;
    float ttl = 6f;

    bool hitDetected = false;
    public void SetDirection(){
        //direction = new Vector3(dir_x, dir_y, 0f);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        //Debug.Log("transform.position:" + transform.position);
        knifeDirection = (mousePos - transform.position).normalized;
        //Debug.Log("knifeDirection:" + knifeDirection);
        float angle = Mathf.Atan2(knifeDirection.y, knifeDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void Update(){
        if(Time.frameCount % 2 == 0){
            transform.position += knifeDirection * speed * Time.deltaTime;
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.3f);
            foreach(Collider2D c in hit){
                IDamageable e = c.GetComponent<IDamageable>();
                if(e != null){
                    PostDamage(damage, transform.position);
                    e.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }
            if(hitDetected == true){
                Destroy(gameObject);
            }
        }

        ttl -= Time.deltaTime;
        if(ttl < 0f){
            Destroy(gameObject);
        }
    }

    public void PostDamage(int damage, Vector3 worldPostion){
        MessageSystem.instance.PostMessage(damage.ToString(), worldPostion);
    }


}
