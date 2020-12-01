using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorClock : MonoBehaviour
{
    // Progress progress = new Progress();
    private int[] number = new int[3];
    
    public Button[] button = new Button[3];
    public GameObject[] hari = new GameObject[3];
    public GameObject[] hari2 = new GameObject[3];
    public ItemListManager itemListManager;

    public Button backButton;
    public Button hintButton;

    public AudioClip soundA;
    public AudioClip soundB;

    void Start(){
        number[0] = 0;
        number[1] = 0;
        number[2] = 0;
    }

    public void PushButton(int i){
        number[i] += 1;
        if(number[i] == 12){
            number[i] = 0;
        }
        hari[i].transform.Rotate(new Vector3(0, 0, -30));
        hari2[i].transform.Rotate(new Vector3(0, 0, -30));
        if(number[0] == 5 && number[1] == 1 && number[2] == 9){
            for(int j = 0; j < button.Length; j++){
            button[j].interactable = false;
            }
            backButton.interactable = false;
            hintButton.interactable = false;
            GetComponent<AudioSource>().PlayOneShot(soundB);
            Invoke("GetMoppu",1);
            
        }else{
            GetComponent<AudioSource>().PlayOneShot(soundA);
        }
    }
    void GetMoppu(){
        itemListManager.SetItem(Item.Moppu);
        itemListManager.UseItem(Item.ClockHint);
        backButton.interactable = true;
        hintButton.interactable = true;
        ProgressManager.Instance.colorClock = 1;
        ProgressManager.Instance.SaveProgress();
    }

    
}
