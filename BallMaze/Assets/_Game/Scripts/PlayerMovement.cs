using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myRB;
    [SerializeField]
    [Range(1f,10f)]
    private float movementSpeed;
    private float dirX,dirY;
    [HideInInspector]
    public bool isMovement;
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody>();
        isMovement=true;
    }

    void Update()
    {
        dirX = Input.acceleration.x * (movementSpeed*Time.deltaTime);
        dirY = Input.acceleration.y * (movementSpeed*Time.deltaTime);
    }

    private void FixedUpdate(){
        myRB.velocity = new Vector2(myRB.velocity.x + dirX, myRB.velocity.y + dirY);
    }
}
