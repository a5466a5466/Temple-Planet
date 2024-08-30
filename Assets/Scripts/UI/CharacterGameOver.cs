using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;

    public PauseManager pauseManager;

    private void Start() {
          pauseManager = FindObjectOfType<PauseManager>();
    }

    public void GameOver()
    {
         Debug.Log("Game over");
         GetComponent<PlayerMove>().enabled = false;
         gameOverPanel.SetActive(true);
         weaponParent.SetActive(false);
         pauseManager.PauseGame();
    }
}
