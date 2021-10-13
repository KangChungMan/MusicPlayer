using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPButton : MonoBehaviour
{
    private SoundManager soundButton;
    public EffectSound effectSound;
    public bool isOn = false;
    public bool musicOn = false;

    // Start is called before the first frame update
    void Start()
    {
        soundButton = GameObject.Find("AudioManager").GetComponent<SoundManager>();
    }
    public void Click()
    {
        Debug.Log("click");
        if (!musicOn)
        {         
            isOn = true;
            musicOn = true;
            soundButton.PlayMusic();
            effectSound.Click();
        }
        else
        {            
            musicOn = false;
            isOn = false;
            soundButton.StopMusic();
            effectSound.ClickOff();
        }

    }

}
