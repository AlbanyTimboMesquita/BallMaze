using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject instance;
  
    private void Awake() {
        MakePersistent();
    }
    private void MakePersistent(){
        if(instance== null){
            instance=this;
        }else{
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
}
