using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoManager : MonoBehaviour
{
    public BeatScroller theBS;

    public static TempoManager instance;

     public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    [SerializeField] TMPro.TextMeshProUGUI scoreText;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    [SerializeField] TMPro.TextMeshProUGUI multiText;


    //public bool canHitFlag;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        //canHitFlag = false;
    }

    public void NormalHit(){
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        //canHitFlag = false;
    }

    public void GoodHit(){
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        //canHitFlag = false;
    }

    public void PerfectHit(){
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        //canHitFlag = false;
    }

    public void NoteHit(){
        //Debug.Log("Note hit!");
        for(int i = 0; i < WeaponManager.instance.weapons.Count; i++){
            WeaponManager.instance.weapons[i].Attack();
        }

        if(currentMultiplier - 1 < multiplierThresholds.Length){
            multiplierTracker++;
            if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker){
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multiText.text = "Multiplier: x" + currentMultiplier;
        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed(){
        //Debug.Log("Note missed!");
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
    }
}
