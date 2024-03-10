using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    private float percentThrehold = 0.2f,easing = 0.5f;
    private int currentPages=1;
    [SerializeField] private int totalPages; 
    void Start()
    {
      panelLocation = transform.position;  
    }
    public void OnDrag(PointerEventData data){
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference,0f,0f);
    }
    public void OnEndDrag(PointerEventData data){
        float percentage = (data.pressPosition.x-data.position.x)/Screen.width;
        if(Mathf.Abs(percentage)>=percentThrehold){
            Vector3 newLocation = panelLocation;
            if(percentage > 0 &&currentPages < totalPages){
                currentPages++;
                newLocation += new Vector3(-Screen.width,0f,0f);
            }else if(percentage < 0 && currentPages > 1){
                currentPages--;
                newLocation += new Vector3(Screen.width,0f,0f);
            }
            StartCoroutine(SmoothMove(transform.position,newLocation,easing));
            panelLocation = newLocation;
        }
    }

    private IEnumerator SmoothMove(Vector3 startPosition, Vector3 endPosition, float seconds)
    {
        float time = 0f;
        while (time <= 1.0f)
        {
            time += Time.deltaTime/seconds;
            transform.position =  Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0f,1f,time));
            yield return null;
        }

    }
}
