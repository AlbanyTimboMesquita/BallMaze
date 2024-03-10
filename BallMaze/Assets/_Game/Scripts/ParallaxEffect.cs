using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float lenght, startPos;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float ParallaxSpeed;
    void Start()
    {
        startPos=transform.position.x;
        lenght= GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (mainCamera.transform.position.x *(1-ParallaxSpeed));
        float dist = (mainCamera.transform.position.x * ParallaxSpeed);
        transform.position = new Vector3(startPos+dist,transform.position.y,transform.position.z);

        if(temp>startPos + lenght){
            startPos += lenght;
        }else if(temp < startPos - lenght){
            startPos -= lenght;
        }
        
    }
}
