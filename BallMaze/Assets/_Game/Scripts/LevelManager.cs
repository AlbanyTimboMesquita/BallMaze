using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public UnityEngine.UI.Button[] btnLevels;
    void Start(){
        for (int i = 0; i < btnLevels.Length; i++)
        {
            int index = i;
            btnLevels[i]=GetComponentsInChildren<UnityEngine.UI.Button>()[i];
            btnLevels[i].onClick.AddListener(()=> LoadLevelByIndex((i-i)+(index+1)));
            
            
        }
        
    }


    void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
