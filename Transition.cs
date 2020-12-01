using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public ItemListManager itemListManager;

    public GameObject walls;//壁の全体パネル
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject backButton;

    public AudioClip openDoorSE;
    public AudioClip keySe;
    public AudioClip correctSE;
    public AudioClip dontOpenDoorSE;

    private int wallNo;//壁の番号
    private int roomNo;//部屋の番号

    public bool doesOpenDoor = false;

    void Start()
    {
        wallNo = 1;
        roomNo = 1;
    }

    //右の壁へ移動
    public void PushButtonRight(){
        wallNo--;
        if(wallNo == 0 && roomNo == 1){
            wallNo = 4;
        }
        if(wallNo == 4 && roomNo == 2){
            wallNo = 8;
        }
        DisplayWall();
    }

    //左の壁へ移動
    public void PushButtonLeft(){
        wallNo++;
        if(wallNo == 5 && roomNo == 1){
            wallNo = 1;
        }
        if(wallNo == 9 && roomNo == 2 ){
            wallNo = 5;
        }
        DisplayWall();
    }

    //壁の画面を表示
    void DisplayWall(){
        switch(wallNo){
        case 1:
            walls.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
            break;
        case 2:
            walls.transform.localPosition = new Vector3 (1000.0f, 0.0f, 0.0f);
            break;
        case 3:
            walls.transform.localPosition = new Vector3 (2000.0f, 0.0f, 0.0f);
            break;
        case 4:
            walls.transform.localPosition = new Vector3 (3000.0f, 0.0f, 0.0f);
            break;
        case 5:
            walls.transform.localPosition = new Vector3 (3000.0f, 2000.0f, 0.0f);
            break;
        case 6:
            walls.transform.localPosition = new Vector3 (4000.0f, 2000.0f, 0.0f);
            break;
        case 7:
            walls.transform.localPosition = new Vector3 (5000.0f, 2000.0f, 0.0f);
            break;
        case 8:
            walls.transform.localPosition = new Vector3 (6000.0f, 2000.0f, 0.0f);
            break;

        case 11:
        walls.transform.localPosition = new Vector3 (0.0f, -2000.0f, 0.0f);
        break;

        case 61:
        walls.transform.localPosition = new Vector3 (4000.0f, 4000.0f, 0.0f);
        break;
        }
    }
    //BACKボタン
    public void PushButtonBack(){
        DisplayWall();
        if(wallNo < 10){
            leftButton.SetActive(true);
            rightButton.SetActive(true);
            backButton.SetActive(false);
        }
        if(wallNo == 11){
            wallNo = 1;
        }else if(wallNo == 61){
            wallNo = 6;
        }
    }
    //左右のボタンを非表示にして、戻るボタンを表示する
    void UnDisplayButton(){
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        backButton.SetActive(true);
    }

    //ホーム画面へ移動
    public void HomeButton(){
        SceneManager.LoadScene("TitleScene");
    }

    //アナログ時計の画面へ移動
    public void PushAnalogDokei(){
        walls.transform.localPosition = new Vector3 (0.0f, -2000.0f, 0.0f);
        UnDisplayButton();
    }
    //レンガ下画面へ移動
    public void GoToRengaBottom(){
        walls.transform.localPosition = new Vector3 (1000.0f, -4000.0f, 0.0f);
        UnDisplayButton();
    }

    //Number5画面へ移動
    public void GoToNumber5(){
        walls.transform.localPosition = new Vector3 (1000.0f, -2000.0f, 0.0f);
        UnDisplayButton();
    }

    //Alphabet4画面へ移動
    public void GoToAlphabet4(){
        walls.transform.localPosition = new Vector3 (6000.0f, 6000.0f, 0.0f);
        UnDisplayButton();
    }

    //カレンダー画面へ移動
    public void GoToCalender(){
        walls.transform.localPosition = new Vector3 (2000.0f, -2000.0f, 0.0f);
        UnDisplayButton();
    }

    //ドアGOAL画面へ移動
    public void GoToDoorGoal(){
        walls.transform.localPosition = new Vector3 (6000.0f, 4000.0f, 0.0f);
        UnDisplayButton();
    }

    //色時計ヒント画面へ移動
    public void GoToClockHint(){
        walls.transform.localPosition = new Vector3 (0.0f, -6000.0f, 0.0f);
        UnDisplayButton();
        wallNo = 11;
    }

    //木１画面へ移動
    public void PushTreeA(){
        walls.transform.localPosition = new Vector3 (0.0f, -4000.0f, 0.0f);
        UnDisplayButton();
    }

    //角ナンバー入力フォーム画面へ移動
    public void PushKadoNumber(){
        walls.transform.localPosition = new Vector3 (0.0f, -2000.0f, 0.0f);
        UnDisplayButton();
    }

    //マーク５画面へ移動
    public void GoToMark5(){
        walls.transform.localPosition = new Vector3 (2000.0f, -6000.0f, 0.0f);
        UnDisplayButton();
    }

    //キャンドルヒント画面へ移動
    public void GoToCandleHint(){
        walls.transform.localPosition = new Vector3 (3000.0f, -2000.0f, 0.0f);
        UnDisplayButton();
    }

    //デジタル数字画面１へ移動
    public void GoToDejital(){
        walls.transform.localPosition = new Vector3 (4000.0f, 4000.0f, 0.0f);
        UnDisplayButton();
    }

    //デジタル数字入力画面へ移動
    public void GoToInputNumber(){
        walls.transform.localPosition = new Vector3 (4000.0f, 10000.0f, 0.0f);
        UnDisplayButton();
        wallNo = 61;
    }

    //パンダヒント画面へ移動
    public void GoToPandaHint(){
        walls.transform.localPosition = new Vector3 (4000.0f, 8000.0f, 0.0f);
        UnDisplayButton();
        wallNo = 61;
    }

    //キャンドル画面へ移動
    public void GoToCandle(){
        walls.transform.localPosition = new Vector3 (3000.0f, 4000.0f, 0.0f);
        UnDisplayButton();
    }

    //ドアを開けてAの部屋に移動
    public void GoToRoomA(){
        walls.transform.localPosition = new Vector3 (1000.0f, 0.0f, 0.0f);
        GetComponent<AudioSource>().PlayOneShot(openDoorSE);
        roomNo = 1;
        wallNo = 2;
    }

    //Aの部屋のドアAを押したとき
    public void PushDoorA(){
        //初めて開ける時
        if(ProgressManager.Instance.openDoor == 0){
            if(itemListManager.selectItem == Item.KeyA){
                GetComponent<AudioSource>().PlayOneShot(keySe);
                Invoke("OpenDoor",1);
                roomNo = 2;
                wallNo = 5;
                itemListManager.UseItem(Item.KeyA);
                itemListManager.SaveItem();
                ProgressManager.Instance.openDoor = 1;
                ProgressManager.Instance.SaveProgress();
            }else{
                GetComponent<AudioSource>().PlayOneShot(dontOpenDoorSE);
            }
        }else if(ProgressManager.Instance.openDoor == 1){
            //２回め以降
            walls.transform.localPosition = new Vector3 (3000.0f, 2000.0f, 0.0f);
            GetComponent<AudioSource>().PlayOneShot(openDoorSE);

            roomNo = 2;
            wallNo = 5;
        }
      
    }


    void OpenDoor(){
        walls.transform.localPosition = new Vector3 (3000.0f, 2000.0f, 0.0f);
        GetComponent<AudioSource>().PlayOneShot(correctSE);
    }
    //５つマーク入力画面へ移動
    public void Push5MarkNyuuryokuGamen(){
        walls.transform.localPosition = new Vector3 (2000.0f, -4000.0f, 0.0f);
        UnDisplayButton();
    }

    public void GoToHondana(){
        walls.transform.localPosition = new Vector3 (5000.0f, 4000.0f, 0.0f);
        UnDisplayButton();
    }

    //もみじの画面
    public void GoToMomiji(){
        walls.transform.localPosition = new Vector3 (0.0f, -4000.0f, 0.0f);
        UnDisplayButton();
    }

    //ひまわりの画面    
    public void GoToHimawari(){
        walls.transform.localPosition = new Vector3 (2000.0f, -4000.0f, 0.0f);
        UnDisplayButton();
    }

    //桜の画面
    public void GoToSakura(){
        walls.transform.localPosition = new Vector3 (3000.0f, 6000.0f, 0.0f);
        UnDisplayButton();
    }

    //もみの木の画面
    public void GoToMominoki(){
        walls.transform.localPosition = new Vector3 (4000.0f, 6000.0f, 0.0f);
        UnDisplayButton();
    }
}
