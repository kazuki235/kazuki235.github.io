using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static int saveData = 1;

    public AudioClip startSE;

    public bool DontDestroyEnabled = true;

    void Awake(){
        if (DontDestroyEnabled) {
            //Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad (this);
        }
    }

    public void PushStartButton(){
        GetComponent<AudioSource>().PlayOneShot(startSE);
        saveData = 0;
        FadeManager.Instance.LoadScene ("GameScene", 0.5f);
    }

   //つづきから
    public void PushLoadButton(){
        GetComponent<AudioSource>().PlayOneShot(startSE);
        saveData = 1;
        FadeManager.Instance.LoadScene ("GameScene", 0.5f);
        
    }
}
