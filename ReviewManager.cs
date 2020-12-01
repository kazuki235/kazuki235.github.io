using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewManager : MonoBehaviour
{
  public void PushReviewButton(){
    #if UNITY_ANDROID
      Application.OpenURL( "https://play.google.com/store/apps/details?id=com.kazuaki.TheRoom" );
    #elif UNITY_IOS
    #endif
  }
}
