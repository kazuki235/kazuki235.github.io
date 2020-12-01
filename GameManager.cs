using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ItemListManager itemListManager;

    public GameObject walls;
    public GameObject doorA;
    public GameObject yogore;
    public GameObject lighterImage;
    public GameObject lighterButton;
    public GameObject setBook;

    public AudioClip moppuSound;
    public AudioClip correctSound;
    public AudioClip kanseiSE;

    public Button rightButton;
    public Button leftButton;
    public Button backButton;

    public GameObject bookImage;
    public GameObject bookImage2;
    public GameObject backButtonObject;

    public bool DontDestroyEnabled = true;

    void Awake(){
        if (DontDestroyEnabled) {
            //Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad (this.gameObject);
        }
    }
    
    void Start()
    {   
        Instance = GetComponent<GameManager>();
    }
    
    public void GetKeyA(){
        itemListManager.SetItem(Item.KeyA);
    }

    //壁の汚れを落とす
    public void PushYogore(){
        if(itemListManager.selectItem == Item.Moppu){
            GetComponent<AudioSource>().PlayOneShot(moppuSound);
            Invoke("Yogore",2);
        }
    }
    void Yogore(){
        GetComponent<AudioSource>().PlayOneShot(correctSound);
        yogore.SetActive(false);
        itemListManager.UseItem(Item.Moppu);
        ProgressManager.Instance.yogore = 1;
        ProgressManager.Instance.SaveProgress();
    }
    //ライターを入手
    public void GetLighter(){
        itemListManager.SetItem(Item.Lighter);
        lighterImage.SetActive(false);
        lighterButton.SetActive(false);
        ProgressManager.Instance.getLighter = 1;
        ProgressManager.Instance.SaveProgress();
    }
    
    //本棚に本をセットする
    public void SetBook(){
        if(itemListManager.selectItem == Item.Book){
            GetComponent<AudioSource>().PlayOneShot(correctSound);
            setBook.SetActive(false);
            bookImage.SetActive(true);
            bookImage2.SetActive(true);
            itemListManager.UseItem(Item.Book);
            ProgressManager.Instance.setBook = 1;
            ProgressManager.Instance.SaveProgress();
        }
    }
    //ホームボタン
    public void PushHomeButton(){
        SceneManager.LoadScene("TitleScene");
    }
    //ボタンを表示する
    public void DisplayButton(){
        rightButton.interactable = true;
        leftButton.interactable = true;
        backButton.interactable = true;
    }
    //ボタンを非表示にする
    public void HiddenButton(){
        rightButton.interactable = false;
        leftButton.interactable = false;
        backButton.interactable = false;
    }   

    public void GameClear(){
        Invoke("Clear",2);
    }

    void Clear(){
        walls.transform.localPosition = new Vector3 (6000.0f, 6000.0f, 0.0f);
        backButtonObject.SetActive(false);
        Invoke("FadeOut",2);
        
    }

    void FadeOut(){
        GetComponent<AudioSource>().PlayOneShot(kanseiSE);
        FadeManager.Instance.LoadScene ("ClearScene", 2.0f);
    }

}


