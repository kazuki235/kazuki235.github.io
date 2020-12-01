using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneManager : MonoBehaviour
{
    public void ClearSceneButton(){
        FadeManager.Instance.LoadScene ("TitleScene", 2.0f);
    }
}
