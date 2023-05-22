using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    private const string _settingsFilename = "settings.txt";
    private static bool _isMuted;
    public static bool IsMuted
    {
        get => _isMuted;
        set { 
            _isMuted = value;
            SaveSettings();
        }
    }
    private static float _BgValume;
    public static float BgValume
    {
        get =>_BgValume; 
        set { _BgValume = value; 
            SaveSettings();
        }
    }
    public static void SaveSettings()
    {
        string path = Application.persistentDataPath + "/" + _settingsFilename;
        string data = $"{_isMuted}\n{_BgValume}";
        File.WriteAllText(path, data);
    }

    public static void LoadSettings()
    { 
        string path = Application.persistentDataPath + "/" + _settingsFilename;
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            _isMuted = (lines.Length > 0) ? Convert.ToBoolean(lines[0]):false ;
            _BgValume = (lines.Length > 1) ? Convert.ToSingle(lines[1]) : 0;
        }
    }
}
