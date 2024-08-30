using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPressed;
    public KeyCode keyToPressed2;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPressed)||Input.GetKeyDown(keyToPressed2)){
            if(canBePressed){
                //TempoManager.instance.NoteHit();
                if(Mathf.Abs(transform.position.x - TempoManager.instance.transform.position.x) <= 0.15){
                    //Debug.Log("Perfect Hit! Distance:" + Mathf.Abs(transform.position.x - TempoManager.instance.transform.position.x));
                    TempoManager.instance.PerfectHit();
                    Instantiate(perfectEffect, TempoManager.instance.transform.position, perfectEffect.transform.rotation, TempoManager.instance.transform);

                }else if(Mathf.Abs(transform.position.x - TempoManager.instance.transform.position.x) <= 0.3){
                    //Debug.Log("Good Hit! Distance:" + Mathf.Abs(transform.position.x - TempoManager.instance.transform.position.x));
                    TempoManager.instance.GoodHit();
                    Instantiate(goodEffect,TempoManager.instance.transform.position,goodEffect.transform.rotation, TempoManager.instance.transform);

                }else{
                    //Debug.Log("Normal Hit! Distance:" + Mathf.Abs(transform.position.x - TempoManager.instance.transform.position.x));
                    TempoManager.instance.NormalHit();
                    Instantiate(hitEffect, TempoManager.instance.transform.position,hitEffect.transform.rotation, TempoManager.instance.transform);

                }
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "ButtonActivator"){
            canBePressed = true;
        }
        if(other.tag == "EliminatorLine"){
            Destroy(this.gameObject);
            TempoManager.instance.NoteMissed();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Activator"){
            canBePressed = false;
        }
    }
}
