using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public bool haveDenti;
    public bool haveSyokupan;
    public bool haveDriver;
    public bool haveKeyA;
    public bool haveBook;
    public bool haveKeyB;
    public bool havePicture;
    public bool openDoor;//ドアが開いてるかどうか

    void Start(){
        haveSyokupan = false;
        haveSyokupan = false;
        haveDriver = false;
        haveKeyA = false;
        haveBook = false;
        haveKeyB = false;
        openDoor = false;

    }

    
}
