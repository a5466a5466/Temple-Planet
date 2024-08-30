using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] EmeniesManager enemiesManager;
    StageTime stageTime;
    int eventIndexer;
    PlayerWinManager playerWin;

    private void Awake(){
        stageTime = GetComponent<StageTime>();
    }

    private void Start() {
        playerWin = FindObjectOfType<PlayerWinManager>();
    }

    private void Update() {

        if(eventIndexer >= stageData.stageEvents.Count){ return;}

        if(stageTime.time > stageData.stageEvents[eventIndexer].time){
            switch(stageData.stageEvents[eventIndexer].eventType){
                case StageEventType.SpawnEnemy:
                    SpawnEnemy(false);
                    break;

                case StageEventType.SpawnObject:
                    SpawnObject();
                    break;

                case StageEventType.winStage:
                    WinStage();
                    break;
                
                case StageEventType.SpawnEnemyBoss:
                    SpawnEnemyBoss(true);
                    break;

            }

            Debug.Log(stageData.stageEvents[eventIndexer].message);
            eventIndexer += 1;
        }
    }

    private void SpawnEnemyBoss(bool isBoss)
    {
        enemiesManager.SpawnEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn, isBoss);
    }

    private void WinStage(){
        playerWin.Win();
    }


    private void SpawnEnemy(bool isBoss){
        for(int i = 0; i < stageData.stageEvents[eventIndexer].count; i++){
            enemiesManager.SpawnEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn, isBoss);
        }
        
    }



    private void SpawnObject(){
        for(int i = 0; i < stageData.stageEvents[eventIndexer].count; i++){
            Vector3 positionToSpawn = GameManager.instance.playerTransform.position;
            positionToSpawn += UtilityTools.GenerateRandomPositionSquarePattern(new Vector2(5f,5f));
            //Debug.Log("spawn object!!!");
            SpawnManager.instance.SpawnObject(positionToSpawn, stageData.stageEvents[eventIndexer].objectToSpawn);
        }
    }


}
