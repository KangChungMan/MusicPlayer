using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LProte : MonoBehaviour
{
    private SoundManager audiobutton;
    private LPButton bu;
    private LPButton play;
    float rotspeed = 720f;
    public AudioClip[] musicClips;

    // Start is called before the first frame update
    void Start()
    {

        //GetComponent<LPButton>().gameObject.GetComponent<다른컨퍼넌트>;

        audiobutton = GameObject.Find("AudioManager").GetComponent<SoundManager>();
        bu = GameObject.Find("LPPanButton").GetComponent<LPButton>();
        //play = GameObject.Find("Player Boutton").GetComponent<LPButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bu.isOn == true)
        {
            Quater();
        }
    }
    public void Quater()
    {
        transform.Rotate(new Vector3(0, 0, rotspeed * Time.deltaTime));
    }

}
