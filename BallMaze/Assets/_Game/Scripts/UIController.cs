using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text txtCurrentTime,txtFinalTime;
    private GameController gameController;
    public GameObject panelGame,panelFinishGame,panelPause;
    public bool winGame;
    void Start()
    {
        gameController=FindObjectOfType<GameController>();
        panelFinishGame.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        winGame=false;
        
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
    }
}
