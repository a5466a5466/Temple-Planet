using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource clickSound1;
    public AudioSource clickSound2;
    public KeyCode keyToPress1;
    public KeyCode keyToPress2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress1)){
           PlayClickSound1();
        }
        if(Input.GetKeyDown(keyToPress2)){
           PlayClickSound2();
        }

    }
    
    private void PlayClickSound1(){
        clickSound1.Play();
    }

    private void PlayClickSound2(){
        clickSound2.Play();
    }
}
