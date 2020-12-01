using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Item{
    None,
    ClockHint,
    Moppu,
    KeyA,
    Lighter,
    Book,
    ThreeButton,
    Album
}

[System.Serializable]
public class ItemList{

    public Item[] itemList;
}

public class ItemListManager : MonoBehaviour
{
    public static ItemListManager Instance = null;

    public static ItemListManager GetInstance(){
        return Instance;
    }

    public Image[] itemListImage = new Image[5];
    public Sprite keyASprite;
    public Sprite moppuSprite;
    public Sprite lighterSprite;
    public Sprite bookSprite;
    public Sprite threeButtonObjectSprite;
    public Sprite albumSprite;
    public Sprite clockHintSprite;
    public GameObject keyAItem;
    public GameObject itemImageBack;
    public GameObject closeButton;
    public GameObject imageBack;
    public GameObject imageBack2;
    public GameObject getItemImage;
    public Sprite blackImage;
    public GameObject keyADetail;
    public GameObject clockHintDetail;
    public GameObject moppuDetail;
    public GameObject lighterDetail;
    public GameObject bookDetail;
    public GameObject threeButtonObjectDetail;
    public GameObject albumDetail;
    public GameObject album1;
    public GameObject album2;
    public GameObject album3;
    public GameObject album4;
    public AudioClip getItemSE;
    public Button rightButton;
    public Button leftButton;
    public Button backButton;
    public AudioClip selectSE;

    public Item[] itemList = new Item[5];

    public GameObject[] selectImage = new GameObject[5];
    public List<GameObject> itemDetailList = new List<GameObject>();
    
    public int selectNumber = -1;

    public Item selectItem;
    AudioSource getItemSESource;

    void Start(){
        Instance = GetComponent<ItemListManager>();
        getItemSESource = GetComponent<AudioSource>();
        if(TitleManager.saveData == 0){
            DeleteItem();
            SaveItem();
        }else if(TitleManager.saveData == 1){
            LoadItem();
        }
    }

    //セーブ
    public void SaveItem(){
        ES3.Save<string>("ItemKey", JsonUtility.ToJson(this));
    }

    //ロード
    public void LoadItem(){
        string json = ES3.Load<string>("ItemKey");
        ItemList instance = JsonUtility.FromJson<ItemList>(json);
        for(int i = 0; i < instance.itemList.Length; i++){

            //データとして保存
            itemList[i] = instance.itemList[i];

            //UIとして反映
            switch(itemList[i]){
                case Item.ClockHint:
                    itemListImage[i].sprite = clockHintSprite;
                    break;

                case Item.Moppu:
                    itemListImage[i].sprite = moppuSprite;
                    break;

                case Item.Lighter:
                    itemListImage[i].sprite = lighterSprite;
                    break;

                case Item.Book:
                    itemListImage[i].sprite =bookSprite;
                    break;

                case Item.ThreeButton:
                    itemListImage[i].sprite = threeButtonObjectSprite;
                    break;
                    
                case Item.KeyA:
                    itemListImage[i].sprite = keyASprite;
                    break;

                case Item.Album:
                    itemListImage[i].sprite = albumSprite;
                    break;
            }
        }
    }

    public void DeleteItem(){
        ES3.DeleteKey("ItemKey");
    }

    public void SetItem(Item item){
        
        for(int i = 0; i < itemList.Length; i++){
            if(itemList[i] == Item.None){
                //アイテムゲット画面を表示
                imageBack2.SetActive(true);
                itemImageBack.SetActive(true);
                closeButton.SetActive(true);
                getItemImage.SetActive(true);

                getItemSESource.PlayOneShot(getItemSE);

                itemList[i] = item;
                // SaveItem();

                switch(item){
                    case Item.ClockHint:
                    getItemImage.GetComponent<Image>().sprite = clockHintSprite;
                    itemListImage[i].sprite = clockHintSprite;
                    break;

                    case Item.Moppu:
                    getItemImage.GetComponent<Image>().sprite = moppuSprite;
                    itemListImage[i].sprite = moppuSprite;
                    break;

                    case Item.Lighter:
                    getItemImage.GetComponent<Image>().sprite = lighterSprite;
                    itemListImage[i].sprite = lighterSprite;
                    break;

                    case Item.Book:
                    getItemImage.GetComponent<Image>().sprite = bookSprite;
                    itemListImage[i].sprite =bookSprite;
                    break;

                    case Item.ThreeButton:
                    getItemImage.GetComponent<Image>().sprite = threeButtonObjectSprite;
                    itemListImage[i].sprite = threeButtonObjectSprite;
                    break;
                    
                    case Item.KeyA:
                    getItemImage.GetComponent<Image>().sprite = keyASprite;
                    itemListImage[i].sprite = keyASprite;
                    break;

                    case Item.Album:
                    getItemImage.GetComponent<Image>().sprite = albumSprite;
                    itemListImage[i].sprite = albumSprite;
                    break;

                }
                break;
            }
        }
        SaveItem();
    }

    public void SelectItem(int index){
        selectItem = itemList[index];
        //選択したボタンが空の場合
        if(selectItem == Item.None){
            return;
            //選択したボタンにアイテムが入っている場合
        }else{
            //SE
            GetComponent<AudioSource>().PlayOneShot(selectSE);
            
            //何もアイテムが選択されていない場合
            if(selectNumber == -1){
                selectImage[index].SetActive(true);
                selectNumber = index;
            }
            //アイテムが選択されている場合
            else{
                
                //選択したアイテムが、選択状態の場合
                if(selectNumber == index){
                    ItemDetailSetActve(true);

                    switch(selectItem){
                        case Item.KeyA:
                        keyADetail.SetActive(true);
                        break;

                        case Item.ClockHint:
                        clockHintDetail.SetActive(true);
                        break;

                        case Item.Moppu:
                        moppuDetail.SetActive(true);
                        break;

                        case Item.Lighter:
                        lighterDetail.SetActive(true);
                        break;

                        case Item.Book:
                        bookDetail.SetActive(true);
                        break;

                        case Item.ThreeButton:
                        threeButtonObjectDetail.SetActive(true);
                        break;

                        case Item.Album:
                        albumDetail.SetActive(true);
                        break;
                    }
                }   
                //選択したアイテムが、非選択状態の場合
                else if(selectNumber != index){
                    selectImage[selectNumber].SetActive(false);
                    selectImage[index].SetActive(true);
                    selectNumber = index;

                    ItemDetailSetActve(false);
                    for(int i = 0; i < itemDetailList.Count; i++){
                        itemDetailList[i].SetActive(false);
                    }
                }
            }
        }
    }

    public void UseItem(Item item){
       
        int useItemNumber = -1;
        int itemCount = -1;
        //使うアイテムを持っているかどうかを取得する
        for(int i = 0; i < itemList.Length; i++){
            if(itemList[i] == item){
                useItemNumber = i;
            }
        }
        //末尾のアイテムの番号を取得
        for(int i = 0; i < itemList.Length; i++){
            if(itemList[i] != Item.None){
                itemCount++;
            }
        }
        //そのアイテムをもっていない場合は何もしない
        if(useItemNumber == -1){
            return;
            //そのアイテムを持っている場合
        }else{
            //最後の場合は削除するだけ
            if(useItemNumber == itemCount){
                itemList[useItemNumber] = Item.None;
                itemListImage[useItemNumber].sprite = blackImage;

                //削除するアイテムが選択状態の場合、非選択状態にする
                if(selectNumber == useItemNumber){
                    selectImage[useItemNumber].SetActive(false);
                    selectNumber = -1;
                }

            //途中の場合は削除して左詰めにする
            }else if(useItemNumber < itemCount){

                for(int i = useItemNumber; i < itemCount; i++){
                itemList[i] = itemList[i + 1];
                itemListImage[i].sprite = itemListImage[i + 1].sprite;
                }
                //アイテム欄の末尾を空にする
                itemList[itemCount] = Item.None;
                itemListImage[itemCount].sprite = blackImage;

                //削除するアイテムが選択状態の場合、非選択状態にする
                if(selectNumber == useItemNumber){
                    selectImage[useItemNumber].SetActive(false);
                    selectNumber = -1;
                
                //選択状態を左詰めにする
                }else if(selectNumber > useItemNumber && selectNumber <= itemCount){
                    selectImage[selectNumber - 1].SetActive(true);
                    selectImage[selectNumber].SetActive(false);
                    selectNumber -= 1;
                }
            }
        }
        SaveItem();
    }
    public void CloseButton(){
        ItemDetailSetActve(false);
        imageBack2.SetActive(false);
        getItemImage.SetActive(false);
        threeButtonObjectDetail.SetActive(false);
        album1.SetActive(false);
        album2.SetActive(false);
        album3.SetActive(false);
        album4.SetActive(false);
        getItemImage.GetComponent<Image>().sprite = null;
        selectItem = Item.None;

        for(int i = 0; i < itemDetailList.Count; i++){
            itemDetailList[i].SetActive(false);
        }
        if(selectNumber != -1){
            selectImage[selectNumber].SetActive(false);
            selectNumber = -1;
        }
    }

    //アイテム詳細画面を表示したり非表示にしたりする
    public void ItemDetailSetActve(bool isOn){
        itemImageBack.SetActive(isOn);
        closeButton.SetActive(isOn);
        imageBack.SetActive(isOn);
    }

}
    


