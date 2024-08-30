using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller_left : MonoBehaviour
{
    [SerializeField] public float beatSpeed;
    

    private void FixedUpdate() {
        transform.position += new Vector3(beatSpeed * Time.deltaTime, 0f, 0f);
    }
}
