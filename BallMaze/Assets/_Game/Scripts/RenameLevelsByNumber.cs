using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RenameLevelsByNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text[] txtLevels;
    void Start()
    {
        for (int i = 0; i < txtLevels.Length; i++){
            txtLevels[i]=GetComponentsInChildren<TMP_Text>()[i];
            txtLevels[i].text = "Nível " +(i+1).ToString();            
        }
    }

}
