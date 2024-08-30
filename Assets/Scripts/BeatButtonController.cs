using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress1;
    public KeyCode keyToPress2;

    private void Start() {
        theSR = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if(Input.GetKeyDown(keyToPress1)||Input.GetKeyDown(keyToPress2)){
            theSR.sprite = pressedImage;
        }
        if(Input.GetKeyUp(keyToPress1)||Input.GetKeyUp(keyToPress2)){
            theSR.sprite = defaultImage;
        }
    }
}
