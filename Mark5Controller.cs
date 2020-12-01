using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mark5Controller : MonoBehaviour
{
    public ItemListManager itemListManager;
    public Button backButton;
    public AudioClip buttonSe;
    public AudioClip correctSe;

    private int[] number = new int[5];
    public Image[] image = new Image[5];
    public Image[] image2 = new Image[5];
    public Sprite[] mark = new Sprite[5];
    public Button[] button = new Button[5];

    // Start is called before the first frame update
    void Start()
    {
        number[0] = 4;
        number[1] = 0;
        number[2] = 3;
        number[3] = 2;
        number[4] = 1;
    }

    public void PushButton(int i){
        number[i] += 1;
        if(number[i] == 5){
            number[i] = 0;
        }
        image[i].sprite = mark[number[i]];
        image2[i].sprite = mark[number[i]];
        if(number[0] == 4 && number[1] == 3 && number[2] == 2 && number[3] == 1 && number[4] == 0){
            backButton.interactable = false;
            GetComponent<AudioSource>().PlayOneShot(correctSe);
            for(int j = 0; j < button.Length; j++){
                button[j].interactable = false;
            }
            Invoke("GetKeyA", 1);
        }else{
            GetComponent<AudioSource>().PlayOneShot(buttonSe);
        }
    }
    void GetKeyA(){
        itemListManager.SetItem(Item.KeyA);
        itemListManager.SaveItem();
        backButton.interactable = true;
        ProgressManager.Instance.mark5 = 1;
        ProgressManager.Instance.SaveProgress();
    }
}
