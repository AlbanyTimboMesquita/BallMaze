using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimits : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField]private float distanceX,distanceY;
    void Start()
    {
        SetminAndMaxWidhtHeight();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateXY();
    }
    private void SetminAndMaxWidhtHeight(){
        Vector2 screenDimensions =  Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.width, Screen.safeArea.height));
        maxX = screenDimensions.x - distanceX;
        minX = -screenDimensions.x + distanceX;
        maxY = screenDimensions.y - distanceY;
        minY = -screenDimensions.y + distanceY;
    }
    private void CalculateXY(){
        CalculateX();
        CalculateY();
    }
    private void CalculateX(){
        if(transform.position.x < minX){//esquerda
            Vector2 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }else if(transform.position.x > maxX){//direita
            Vector2 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }
    private void CalculateY(){
        if(transform.position.y < minY){//baixo
            Vector2 temp = transform.position;
            temp.y = minY;
            transform.position = temp;
        }else if(transform.position.y > maxY){//cima
            Vector2 temp = transform.position;
            temp.y = maxY;
            transform.position = temp;
        }
    }
}
