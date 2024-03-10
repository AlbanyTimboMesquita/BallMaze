using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D myRB;
    [SerializeField]
    [Range(1f,10f)]
    private float movementSpeed;
    private float dirX,dirY;
    [HideInInspector]
    public bool isMovement;
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
        isMovement=true;
    }

    void Update()
    {
        if(isMovement){
        dirX = Input.acceleration.x * (movementSpeed*Time.deltaTime);
        dirY = Input.acceleration.y * (movementSpeed*Time.deltaTime);
        }
    }

    private void FixedUpdate(){
        if(isMovement){
        myRB.velocity = new Vector2(myRB.velocity.x + dirX, myRB.velocity.y + dirY);
        }else{
            myRB.velocity = Vector2.zero;
        }
    }
}
