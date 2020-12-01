using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeButton : MonoBehaviour
{
    public ItemListManager itemListManager;
    public Button button1;
    public Button button2;
    public Button button3;

    public AudioClip buttonSE;
    public AudioClip correctSE;

    public GameObject threeButtonObject;

    public GameObject[] offImage = new GameObject[3];
    public GameObject[] onImage = new GameObject[3];

    string[] a = new string[11];

    public void PushTopButton(){
        Input();
        a[0] = "上";
        Debug.Log(a[0]+a[1]+a[2]+a[3]+a[4]+a[5]+a[6]+a[7]);
        Check();
    }
    public void PushCenterButton(){
        Input();
        a[0] = "中";
        Debug.Log(a[0]+a[1]+a[2]+a[3]+a[4]+a[5]+a[6]+a[7]);
        Check();
    }
    public void PushBottomButton(){
        Input();
        a[0] = "下";
        Debug.Log(a[0]+a[1]+a[2]+a[3]+a[4]+a[5]+a[6]+a[7]);
        Check();
    }
    private void Input(){
        for(int i = a.Length - 1; i > 0; i--){
            a[i] = a[i - 1];
        }
        
    }
    private void Check(){
        if(a[0] == "下" && a[1] == "上" && a[2] == "中" && a[3] == "上" && a[4] == "上" && a[5] == "下" && a[6] == "中" && a[7] == "下" && a[8] == "上" && a[9] == "中" && a[10] == "上"){
            GetComponent<AudioSource>().PlayOneShot(correctSE);
            Invoke("GetAlbum", 1);
            button1.interactable = false;
            button2.interactable = false;
            button3.interactable = false;
        }else{
            GetComponent<AudioSource>().PlayOneShot(buttonSE);
        }
        
    }
    void GetAlbum(){
        threeButtonObject.SetActive(false);
        itemListManager.SetItem(Item.Album);
        itemListManager.UseItem(Item.ThreeButton);
    }

    public void PushDown(int i){
        offImage[i].SetActive(false);
        onImage[i].SetActive(true);
    }

    public void PushUp(int i){
        offImage[i].SetActive(true);
        onImage[i].SetActive(false);
    }

    
}
