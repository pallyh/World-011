using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    [SerializeField]
    private Material daySkybox;
    [SerializeField]
    private Material nightSkybox;
    
    private Light _sun;
    private Light _moon;
    const float _fullDayTime = 30f;
    const float _deltaAngel = 360 / _fullDayTime;
    float _dayTime;
    float _dayPhase;

    private AudioSource _daySound;
    private AudioSource _nightSound;
    void Start()
    {
        _sun = GameObject.Find("SunLight").GetComponent<Light>();
        _moon = GameObject.Find("MoonLight").GetComponent<Light>();
        AudioSource[] audioSources = this.GetComponents<AudioSource>();
        _daySound = audioSources[0];
        _nightSound = audioSources[1];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _dayTime += Time.deltaTime;
        _dayTime %= _fullDayTime;
        _dayPhase = _dayTime / _fullDayTime;

        _sun.transform.Rotate(_deltaAngel * Time.deltaTime, 0, 0);
        _moon.transform.Rotate(_deltaAngel * Time.deltaTime, 0, 0);
        
        float koef = Mathf.Abs(Mathf.Cos(_dayPhase * 2f* Mathf.PI ));
        
        if (_dayPhase > 0.25f && _dayPhase < 0.75f)
        {
            if (!_nightSound.isPlaying)
            {
                if (_daySound.isPlaying)
                {
                    _daySound.Stop();
                }
                _nightSound.Play();
            }
            if (RenderSettings.skybox != nightSkybox)
            {
                RenderSettings.skybox = nightSkybox;
            }
            RenderSettings.ambientIntensity = koef / 2f;
            
        }
        else 
        {
            if (!_daySound.isPlaying)
            {
                if (_nightSound.isPlaying)
                {
                    _nightSound.Stop();
                }
                _daySound.Play();
            }
            if (RenderSettings.skybox != daySkybox)
            {
                RenderSettings.skybox = daySkybox;
            }
            RenderSettings.ambientIntensity = koef;
        }
        RenderSettings.skybox.SetFloat("_Exposure", 0.1f + koef * 0.9f);
        SoundChanges();

    }
    public void SoundChanges()
    {
        //      MUTE
        _daySound.mute = GameSetting.IsMuted;
        _nightSound.mute = GameSetting.IsMuted;
        //      CHANGE BACKGROUND VOLUME
        _daySound.volume = GameSetting.BgValume;
        _nightSound.volume = GameSetting.BgValume;

    }
}
