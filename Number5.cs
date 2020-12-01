using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number5 : MonoBehaviour
{
    public Button[] button = new Button[5];
    public Text[] numberText = new Text[5];
    public Text[] subNumberText = new Text[5];
    public ItemListManager itemListManager;
    public AudioClip se;
    public AudioClip se2;
    public Button backButton;
    public GameManager gameManager;

    private int[] number = new int[5];

    public void PushButton(int i){
        number[i] += 1;
        if(number[i] == 10){
            number[i] = 0;
        }
        numberText[i].text = number[i].ToString();
        subNumberText[i].text = number[i].ToString();
        if(number[0] == 7 && number[1] == 1 && number[2] == 5 && number[3] == 2 && number[4] == 3){
            GetComponent<AudioSource>().PlayOneShot(se2);
            backButton.interactable = false;
            for(int j = 0; j < button.Length; j++){
                button[j].interactable = false;
            }

            Invoke("GetHint",1);
            
        }else{
            GetComponent<AudioSource>().PlayOneShot(se);
        }
    }
    void GetHint(){
        itemListManager.SetItem(Item.ClockHint);
        backButton.interactable = true;
        itemListManager.SaveItem();
        ProgressManager.Instance.number5 = 1;
        ProgressManager.Instance.SaveProgress();


    }

}
