using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatNotesCreator_left : MonoBehaviour
{
    [SerializeField] public float beatTempo;
    float totalTime;
    int totalBeats;

    //int sectionCount = 0;
    float sectionTime;

    float[] beatSheet = new float[1000];
    //  part 01 (from 0s to 16.368)
    //      0.067s: blue
    //      1.432s: red

    int beatNumNow;
    
    /*
    //beats points
    //every scetion2.728s
    const float sectionTime = 2.728f;
    //  part 01 (from 0s to 16.368)
    //      0.067s: blue
    //      1.432s: red
    const float p1bn1 = 0.067f;  //ex: part 1 blue note 1
    const float p1rn1 = 1.432f;  //ex: part 1 red note 1
    bool part1flag = true;
    //  part 02(from 16.368 to 65.472)
    //      0.067s: blue
    //      1.412s: red
    //      1.592s: red
    //      2.132s: blue
    const float p2bn1 = 0.067f;  //ex: part 2 blue note 1
    const float p2rn1 = 1.412f;
    const float p2rn2 = 1.592f;  //ex: part 2 red note 2
    const float p2bn2 = 2.132f;
    bool part2flag = false;

    bool beat1Flag = true;
    bool beat2Flag = false;
    bool beat3Flag = false;
    bool beat4Flag = false;

    section 03(from 65.472 to 65.472)
    每節2.728s
    0.050s: blue
    0.400s: blue 
    0.750s: red

    1.414s: blue
    1.764s: blue 
    2.114s: red

    */


    private void Awake() {
        totalTime = 0;
        sectionTime = 4 * 60f / beatTempo;
        //timer = 0.728f;//timeToCreateNote + p1bn1; //set first beat note time
        beatNumNow = 0;
        CreateBeatSheet();
    }


    private void FixedUpdate() {
        if(totalTime >= beatSheet[beatNumNow+1] - 0.05f && totalTime <= (beatSheet[beatNumNow+1] + 0.05f)){
            SpawnNote();
            beatNumNow ++;
            //Debug.Log("beatNum:" + beatNumNow + "Total Time:" + totalTime);
        }

        /** Old way
        //just for test, a better way is to use beats table.
        if(timer <= 0 && part1flag ==true){
            Debug.Log("section count:" + sectionCount);
            
            if(beat1Flag){
                SpawnNote();
                Debug.Log("beat p1-01 Created!");
                timer = p1rn1 - p1bn1;
                beat2Flag = true;
                beat1Flag = false;
            }else{
                SpawnNote();
                Debug.Log("beat p1-02 Created!");
                timer = sectionTime - p1rn1 + p1bn1;
                beat1Flag = true;
                beat2Flag = false;
                sectionCount += 1f;
            }
            if(sectionCount >= 6){ part1flag = false; part2flag = true; timer -= 2.728f;}
        }else if(timer <= 0 && part2flag ==true){
            Debug.Log("section count:" + sectionCount);
            if(beat1Flag){
                SpawnNote();
                Debug.Log("beat p2-01 Created!");
                timer = p2rn1 - p2bn1;
                beat2Flag = true;
                beat1Flag = false;
            }else if(beat2Flag){
                SpawnNote();
                Debug.Log("beat p2-02 Created!");
                timer = p2rn2 - p2rn1;
                beat3Flag = true;
                beat2Flag = false;
            }else if(beat3Flag){
                SpawnNote();
                Debug.Log("beat p2-03 Created!");
                timer = p2bn2 - p2rn2;
                beat4Flag = true;
                beat3Flag = false;
            }else if(beat4Flag){
                SpawnNote();
                Debug.Log("beat p2-04 Created!");
                timer = sectionTime - p2bn2 + p2bn1;
                beat1Flag = true;
                beat4Flag = false;
                sectionCount += 1f;
            }
        }
        */
        //timer -= Time.deltaTime;
        totalTime += Time.deltaTime;
    }
    [SerializeField] GameObject[] NotePrefebs;
    public void SpawnNote(){
        int r = Random.Range(0,NotePrefebs.Length);
        Instantiate(NotePrefebs[0], transform);
        //Vector3 mirrorTransform = transform.position;
        //mirrorTransform.x -= 13.5f;
        //Instantiate(NotePrefebs[1], mirrorTransform, Quaternion.Euler(0, 0, 0));
    }

    private void CreateBeatSheet(){
        int TempTotalBeats = 0;
        int sectionCount = 0;
        for(; sectionCount < 6; sectionCount++){
            beatSheet[TempTotalBeats + (sectionCount)*2] = sectionCount * sectionTime + 0.067f - 0.5f;
            beatSheet[TempTotalBeats + (sectionCount)*2+1] = sectionCount * sectionTime + 1.432f - 0.5f;
            totalBeats +=2;
        }
        TempTotalBeats = totalBeats;
        for(; sectionCount < 25; sectionCount++){
            beatSheet[TempTotalBeats + (sectionCount-6)*4] = sectionCount * sectionTime + 0.067f - 0.5f;
            beatSheet[TempTotalBeats + (sectionCount-6)*4+1] = sectionCount * sectionTime + 1.412f - 0.5f;
            beatSheet[TempTotalBeats + (sectionCount-6)*4+2] = sectionCount * sectionTime + 1.592f - 0.5f;
            beatSheet[TempTotalBeats + (sectionCount-6)*4+3] = sectionCount * sectionTime + 2.132f - 0.5f;
            totalBeats +=4;
        }
        TempTotalBeats = totalBeats;
        for(; sectionCount < 100; sectionCount++){
            beatSheet[TempTotalBeats + (sectionCount-25)*6] = sectionCount * sectionTime + 0.05f -0.5f;
            beatSheet[TempTotalBeats + (sectionCount-25)*6+1] = sectionCount * sectionTime + 0.4f -0.5f;
            beatSheet[TempTotalBeats + (sectionCount-25)*6+2] = sectionCount * sectionTime + 0.750f -0.5f;
            //beatSheet[i*8+3 -8*14] = i * sectionTime + 1.040f -0.5f;

            beatSheet[TempTotalBeats + (sectionCount-25)*6+3] = sectionCount * sectionTime + 1.414f -0.5f;
            beatSheet[TempTotalBeats + (sectionCount-25)*6+4] = sectionCount * sectionTime + 1.764f -0.5f;
            beatSheet[TempTotalBeats + (sectionCount-25)*6+5] = sectionCount * sectionTime + 2.114f -0.5f;
            //beatSheet[i*8+7 -8*14] = i * sectionTime + 2.404f -0.5f;
            totalBeats +=6;
        }

        // Debug.Log(totalBeats);
        // for(int i=0; i< 200; i++){
        //     Debug.Log("["+i+"]"+ beatSheet[i]);
        // }



    }
}
