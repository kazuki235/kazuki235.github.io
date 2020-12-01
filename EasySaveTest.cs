using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySaveTest : MonoBehaviour
{
    int SLInt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveTest(){
        ES3.Save<int>("SLInt", SLInt);
    }

}
