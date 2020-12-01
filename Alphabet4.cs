using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Alphabet4 : MonoBehaviour
{
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;

    public Button[] upButton = new Button[4];
    public Button[] downButton = new Button[4];

    public AudioClip correctSE;
    public Button backButton;
    public GameObject walls;
    public GameManager gameManager;
    public ItemListManager itemListManager;

    private int a;
    private int b;
    private int c;
    private int d;

    public string[] alphabet = new string[26];
    public Text[] text = new Text[4];

    // Start is called before the first frame update
    void Start()
    {
        a = 0;
        b = 0;
        c = 0;
        d = 0;
    }
    public void UpButton(int i){
        switch(i){
            case 0:
            a++;
            if(a == 26){
            a = 1;
            }
            text[0].text = alphabet[a];
            break;

            case 1:
            b++;
            if(b == 26){
            b = 1;
            }
            text[1].text = alphabet[b];
            break;

            case 2:
            c++;
            if(c == 26){
            c = 1;
            }
            text[2].text = alphabet[c];
            break;

            case 3:
            d++;
            if(d == 26){
            d = 1;
            }
            text[3].text = alphabet[d];
            break;

        }
        Debug.Log(a + "," + b + "," + c + "," + d);
        Check();
    }
    public void DownButton(int index){
        switch(index){
            case 0:
            a--;
            if(a == -1){
                a = 25;
            }
            text[0].text = alphabet[a];
            break;

            case 1:
            b--;
            if(b == -1){
                b = 25;
            }
            text[1].text = alphabet[b];
            break;

            case 2:
            c--;
            if(c == -1){
                c = 25;
            }
            text[2].text = alphabet[c];
            break;

            case 3:
            d--;
            if(d == -1){
                d = 25;
            }
            text[3].text = alphabet[d];
            break;

        }
        Debug.Log(a + "," + b + "," + c + "," + d);
        Check();
    }

    void Check(){
        if(a == 7 && b == 12 && c == 18 && d == 12){
            GetComponent<AudioSource>().PlayOneShot(correctSE);
            for(int i = 0; i < 4; i++){
                upButton[i].interactable = false;
                downButton[i].interactable = false;
            }
            backButton.interactable = false;
            itemListManager.UseItem(Item.Album);
            gameManager.GameClear();
            
        }
    }
    

}
