using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumController : MonoBehaviour
{
    public GameObject Album0;
    public GameObject Album1;
    public GameObject Album2;
    public GameObject Album3;
    public GameObject Album4;

    public AudioClip mekuruSE;
    public AudioClip closeBookSE;

    public void AlbumControll(int index){
        switch(index){
            case 0:
            Album0.SetActive(false);
            Album1.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(mekuruSE);
            break;
            case 1:
            Album1.SetActive(false);
            Album2.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(mekuruSE);
            break;
            case 2:
            Album2.SetActive(false);
            Album3.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(mekuruSE);
            break;
            case 3:
            Album3.SetActive(false);
            Album4.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(mekuruSE);
            break;
            case 4:
            Album4.SetActive(false);
            Album0.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(closeBookSE);
            break;
        }
    }
}
