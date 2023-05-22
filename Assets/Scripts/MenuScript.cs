using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject menuContent;
    void Start()
    {
        GameSetting.LoadSettings();
        GameObject.Find("MuteToggle").GetComponent<Toggle>().isOn = GameSetting.IsMuted;
        GameObject.Find("BackgSlide").GetComponent<Slider>().value = GameSetting.BgValume;

        Time.timeScale = menuContent.activeInHierarchy ? 0.0f : 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = menuContent.activeInHierarchy ? 1.0f : 0.01f;
            menuContent.SetActive(!menuContent.activeInHierarchy);
            
        }
    }

    public void MuteChanges(bool state)
    {
        /*Debug.Log(state);*/
        GameSetting.IsMuted = state;
    }
    public void BgVolumeChanges(Single value)
    {
        GameSetting.BgValume = value;
    }
}
