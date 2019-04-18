using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLoad : MonoBehaviour
{
    public Text loadingTxt;
    public Image blackImg;

    // Start is called before the first frame update
    void Start()
    {
        loadingTxt.gameObject.SetActive(false);
        blackImg.gameObject.SetActive(false);
    }

    public void displayLoading()
    {
        loadingTxt.gameObject.SetActive(true);
        blackImg.gameObject.SetActive(true);
    }

}
