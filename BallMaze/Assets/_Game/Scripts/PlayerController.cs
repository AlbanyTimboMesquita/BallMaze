using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController tempGameController =FindObjectOfType<GameController>();
        tempGameController.PosicaoInicial(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D alvo) {
        if(alvo.gameObject.CompareTag("Lose")){
            //Debug.Log("Voce perdeu!");
            GameController tempGameController =FindObjectOfType<GameController>();
           
            tempGameController.Gameover(this.gameObject);
            this.gameObject.GetComponent<Rigidbody2D>().velocity= new Vector2(0f,0f);
        }else if(alvo.gameObject.CompareTag("Win")){
            Debug.Log("Voce ganhou!");
            this.gameObject.GetComponent<PlayerMovement>().isMovement = false;
            GameController tempGameController =FindObjectOfType<GameController>();
            tempGameController.finalTime = tempGameController.currentTime;
            Debug.Log(tempGameController.finalTime);
            UIController tempUIController = FindObjectOfType<UIController>();
            tempUIController.Wingame();
        }
    }
}
