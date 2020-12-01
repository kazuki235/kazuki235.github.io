using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightCandle : MonoBehaviour
{
    public Button[] buttons = new Button[8];
    public GameObject[] fire = new GameObject[8];

    public AudioClip lighterSound;
    public AudioClip putoutSound;

    private int[] doesLight = new int[8]{0, 0, 0, 0, 0, 0, 0, 0};

    public void PushCandle(int index){
        if(doesLight[index] == 0){
            if(ItemListManager.Instance.selectItem == Item.Lighter){
                fire[index].SetActive(true);
                doesLight[index] = 1;
                GetComponent<AudioSource>().PlayOneShot(lighterSound);
                Check();
            }
        }else if(doesLight[index] == 1){
            fire[index].SetActive(false);
            doesLight[index] = 0;
            GetComponent<AudioSource>().PlayOneShot(putoutSound);
            Check();
            }
        }

    void Check(){
        if(doesLight[0] == 1 && doesLight[1] == 0 && doesLight[2] == 1 && doesLight[3] == 0 && doesLight[4] == 1 && doesLight[5] == 0 && doesLight[6] == 1 && doesLight[7] == 0){
            for(int i = 0; i < buttons.Length; i++){
                buttons[i].interactable = false;
            }
            GameManager.Instance.HiddenButton();
            Invoke("GetBook", 1);
        }
    }
    void GetBook(){
        ItemListManager.Instance.SetItem(Item.Book);
        ItemListManager.Instance.UseItem(Item.Lighter);
        ProgressManager.Instance.lightCandle = 1;
        ProgressManager.Instance.SaveProgress();
        GameManager.Instance.DisplayButton();
    }
}
