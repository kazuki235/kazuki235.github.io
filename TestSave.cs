using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSave : MonoBehaviour
{
    public static int count;
    public int count2 = 100;

    public const string key = "a";

    void Start(){
        Load();
        

    }

    public void Save(){
        PlayerPrefs.SetString(key, JsonUtility.ToJson(this));
        PlayerPrefs.Save();
    }

    public void Load(){
        string json = PlayerPrefs.GetString(key);
        Debug.Log(json);

    }
}
