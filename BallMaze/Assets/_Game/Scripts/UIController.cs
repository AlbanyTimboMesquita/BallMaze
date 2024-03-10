using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text txtCurrentTime,txtFinalTime;
    private GameController gameController;
    public GameObject panelGame,panelFinishGame,panelPause;
    public bool winGame;
    public int nextSceneLoad;
    void Start()
    {
        gameController=FindObjectOfType<GameController>();
        panelFinishGame.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        winGame=false;
        nextSceneLoad=SceneManager.GetActiveScene().buildIndex+1;
        
    }
    void Update()
    {
        if(!winGame){
       gameController.currentTime+=Time.deltaTime;
       UpdateText(); 
        }
    }
    public void Wingame(){
        txtFinalTime.text = ConverterTempo(gameController.finalTime);//gameController.finalTime.ToString("00:00");
        panelFinishGame.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);

        if(nextSceneLoad> PlayerPrefs.GetInt("levelAt")){
            PlayerPrefs.SetInt("levelAt",nextSceneLoad);
        }
    }

    private void UpdateText()
    {
        txtCurrentTime.text = ConverterTempo(gameController.currentTime);  
    }

    private string ConverterTempo(float time){
        var seconds =(time % 60);
        var minutes = ((int)(time/60)%60);
        //var hours =(int)(gameController.currentTime/3600);
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    public void ButtonRestartGame(){
        GameObject tempPlayer=GameObject.FindGameObjectWithTag("Player");
        tempPlayer.GetComponent<PlayerMovement>().isMovement = true;
        gameController.Gameover(tempPlayer.gameObject);
        panelFinishGame.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.currentTime=0f;
        winGame=false;
    }
    public void ButtonPause(){
        panelPause.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ButtonResume(){
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ButtonMainMenu(){

        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void ButtonNextLevel(){
        if(SceneManager.GetActiveScene().buildIndex==30){
            SceneManager.LoadScene(0);
        }else{
        SceneManager.LoadScene(nextSceneLoad);
        }
    }
}
