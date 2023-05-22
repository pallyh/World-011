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

    void Start()
    {
        _sun = GameObject.Find("SunLight").GetComponent<Light>();
        _moon = GameObject.Find("MoonLight").GetComponent<Light>();
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
            if (RenderSettings.skybox != nightSkybox)
            {
                RenderSettings.skybox = nightSkybox;
            }
            RenderSettings.ambientIntensity = koef / 2f;
            
        }
        else 
        {
            if (RenderSettings.skybox != daySkybox)
            {
                RenderSettings.skybox = daySkybox;
            }
            RenderSettings.ambientIntensity = koef;
        }
        RenderSettings.skybox.SetFloat("_Exposure", 0.1f + koef * 0.9f);
    }
}
