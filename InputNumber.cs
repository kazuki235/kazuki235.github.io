using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputNumber : MonoBehaviour
{
    public Text outputNumberA;
    public Text outputNumberB;
    public Text outputNumberC;
    public Text outputString;
    public Button[] buttons = new Button[12];

    public AudioClip correctSound;
    public AudioClip blipSound;

    public ItemListManager itemListManager;
   
    private int? a = null;
    private int? b = null;
    private int? c = null;

    public void PushNumberButton(int number){
        Input(number);
        Output();
        Eraze();
    }

    public void PushButton0(){
        if(a == null){
            Debug.Log("Error");
        }else if(a != null && b == null){
            b= 0;
        }else if(a != null && b != null && c ==null){
            c = 0;
        }
        Output();
        Eraze();
    }

    public void PushClearButton(){
        Output();
        ErazeNumber();
    }
    private void Eraze(){
        outputString.text = "";
    }

    private void Output(){
        if( a != null && b == null && c == null){
            outputNumberA.text = "";
            outputNumberB.text = "";
            outputNumberC.text = a.ToString();
        }else if(a != null && b != null && c == null){
            outputNumberA.text = "";
            outputNumberB.text = a.ToString();
            outputNumberC.text = b.ToString();
        }else if(a != null && b != null && c != null){
            outputNumberA.text = a.ToString();
            outputNumberB.text = b.ToString();
            outputNumberC.text = c.ToString();
        }
    }

    private void Input(int i){
        if(a == null){
            a = i;
        }else if(a != null && b == null){
            b = i;
        }else if(a != null && b != null && c ==null){
            c = i;
        }
    }
    public void PushEnterButton(){
        //正解した場合
        if(a == 1 && b == 2 && c == 4){
            ProgressManager.Instance.inputNumber = 1;
            ProgressManager.Instance.SaveProgress();
            GetComponent<AudioSource>().PlayOneShot(correctSound);
            for(int i = 0; i < buttons.Length; i++){
                buttons[i].interactable = false;
            }
            Invoke("GetThreeButton", 1);
            
            
        }else{
            PushClearButton();
            outputString.text = null;
            GetComponent<AudioSource>().PlayOneShot(blipSound);
            ErazeNumber();
        }
    }

    void GetThreeButton(){
        itemListManager.SetItem(Item.ThreeButton);
    }

    private void ErazeNumber(){
            outputNumberA.text = "";
            outputNumberB.text = "";
            outputNumberC.text = "";
            a = null;
            b = null;
            c = null;
    }
}
