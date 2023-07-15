using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Audio : MonoBehaviour
{
    public TMP_Text ses;
    public Slider slider;

    void Start()
    {
        loadses();
    }
    public void sesayar(float value){
        AudioListener.volume = value;
        ses.text = ((int)(value*100)).ToString(); 
        saveses();
    }
    void saveses(){
        PlayerPrefs.SetFloat("sesdeger",AudioListener.volume);
    }
    void loadses(){
        if(PlayerPrefs.HasKey("sesdeger")){
            AudioListener.volume=PlayerPrefs.GetFloat("sesdeger");
            slider.value = PlayerPrefs.GetFloat("sesdeger");
        }
        else{
            PlayerPrefs.SetFloat("sesdeger",1f);
            AudioListener.volume=PlayerPrefs.GetFloat("sesdeger");
            slider.value = PlayerPrefs.GetFloat("sesdeger");
        }
    }
}
