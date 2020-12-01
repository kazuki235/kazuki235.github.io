using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Progress
{
    public int number5;
    public int colorClock;
    public int yogore;
    public int mark5;
    public int openDoor;
    public int getLighter;
    public int lightCandle;
    public int setBook;
    public int inputNumber;

}

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    public int number5 = 0;
    public int colorClock = 0;
    public int yogore = 0;
    public int mark5 = 0;
    public int openDoor = 0;
    public int getLighter = 0;
    public int lightCandle = 0;
    public int setBook = 0;
    public int inputNumber = 0;

    public Button[] colorButton = new Button[3];
    public GameObject[] hari = new GameObject[3];
    public GameObject[] hari2 = new GameObject[3];
    public Button[] number5Button = new Button[5];
    public Text[] number5Text = new Text[5];
    public Text[] number5Text2 = new Text[5];
    public GameObject yogoreObject;
    public Button[] mark5Button = new Button[5];
    public Image[] mark5Image = new Image[5];
    public Sprite[] mark5Sprite = new Sprite[5];
    public Image[] mark5Image2 = new Image[5];
    public GameObject lighterImage;
    public GameObject lighterButton;
    public Button[] candleButton = new Button[8];
    public GameObject[] fire = new GameObject[8];
    public GameObject bookButton;
    public GameObject bookImage;
    public GameObject bookImage2;
    public Button[] inputNumberButton = new Button[12];
    public Text[] inputNumberText = new Text[3];


    void Start(){
        Instance = GetComponent<ProgressManager>();
        if(TitleManager.saveData == 0){
            DeleteProgress();
            SaveProgress();
        }else if(TitleManager.saveData == 1){
            LoadProgress();
        }
    }

    //セーブ
    public void SaveProgress(){
        ES3.Save<string>("ProgressKey", JsonUtility.ToJson(this));
    }

    //ロード
    public void LoadProgress(){
        string json = ES3.Load<string>("ProgressKey");
        Progress instance = JsonUtility.FromJson<Progress>(json);

        number5 = instance.number5;
        colorClock = instance.colorClock;
        yogore = instance.yogore;
        mark5 = instance.mark5;
        openDoor = instance.openDoor;
        getLighter = instance.getLighter;
        lightCandle = instance.lightCandle;
        setBook = instance.setBook;
        inputNumber = instance.inputNumber;

        //Number5
        if(instance.number5 == 1){
            for(int i = 0; i < number5Button.Length; i++){
                number5Button[i].interactable = false;
            }
            number5Text[0].text = "7";
            number5Text[1].text = "1";
            number5Text[2].text = "5";
            number5Text[3].text = "2";
            number5Text[4].text = "3";
            number5Text2[0].text = "7";
            number5Text2[1].text = "1";
            number5Text2[2].text = "5";
            number5Text2[3].text = "2";
            number5Text2[4].text = "3";
        }

        //ColorClock
        if(instance.colorClock == 1){
            colorButton[0].interactable = false;
            colorButton[1].interactable = false;
            colorButton[2].interactable = false;
            hari[0].transform.Rotate(new Vector3(0, 0, -150));//赤
            hari[1].transform.Rotate(new Vector3(0, 0, -30));//青
            hari[2].transform.Rotate(new Vector3(0, 0, -270));//黃
            hari2[0].transform.Rotate(new Vector3(0, 0, -150));//赤
            hari2[1].transform.Rotate(new Vector3(0, 0, -30));//青
            hari2[2].transform.Rotate(new Vector3(0, 0, -270));//黃
        }

        //汚れ
        if(instance.yogore == 1){
            yogoreObject.SetActive(false);
        }

        //Mark5
        if(instance.mark5 == 1){
            for(int i = 0; i < mark5Button.Length; i++){
                mark5Button[i].interactable = false;
                mark5Image[i].sprite = mark5Sprite[i];
                mark5Image2[i].sprite = mark5Sprite[i];
            }
        }

        //OpenDoor
        if(instance.openDoor == 1){
            
        }

        //ライターをゲットしたかどうか
        if(instance.getLighter == 1){
            lighterImage.SetActive(false);
            lighterButton.SetActive(false);
        }

        //LightCandle
        if(instance.lightCandle == 1){
            for(int i = 0; i < candleButton.Length; i++){
                candleButton[i].interactable = false;
            }
            fire[0].SetActive(true);
            fire[2].SetActive(true);
            fire[4].SetActive(true);
            fire[6].SetActive(true);
        }

        //SetBook
        if(instance.setBook == 1){
            bookButton.SetActive(false);
            bookImage.SetActive(true);
            bookImage2.SetActive(true);
        }

        //InputNumber
        if(inputNumber == 1){
            for(int i = 0; i < 12; i++){
                inputNumberButton[i].interactable = false;
            }
            inputNumberText[0].text = "1";
            inputNumberText[1].text = "2";
            inputNumberText[2].text = "4";
        }

    }
    public void DeleteProgress(){
        ES3.DeleteKey("ProgressKey");
    }

    public void Debaggu(){
        Debug.Log(mark5);
    }
}
