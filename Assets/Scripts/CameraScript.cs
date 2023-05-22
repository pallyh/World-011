using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject _character;  //ссылка на обьект персонаж
    private Vector3 _offset;        //смещение каммеры и персонажа
    private float _angleX;          //накопленный угол поворота по X каммеры
    private float _angleY;          //накопленный угол поворота по Y каммеры
    private float _sensX = 450;     //Чуствительность поворотов по X каммеры
    private float _sensY = 200;     //Чуствительность поворотов по Y каммеры

    void Start()
    {
        _character = GameObject.Find("Character"); //поиск по имени обьекта в юнити
        _offset = this.transform.position - _character.transform.position;
        _angleX = 0;
        _angleY = this.transform.eulerAngles.x; //смещение по У = вращение по Х
    }

    private void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        _angleX += mx * Time.deltaTime * _sensY;
        if (_angleY > 30 || _angleY < -45)
        {
            if (_angleY > 30)
            {
                _angleY = 30;
            }
            else
            {
                _angleY = -45;
            }
        }
        else
        {
            _angleY -= my * Time.deltaTime * _sensX;
        }
        
    }

    void LateUpdate()
    {
        this.transform.position = 
            _character.transform.position + 
            Quaternion.Euler(0,_angleX,0) * _offset;
        if (!Input.GetMouseButton(1))//0 - left , 1 - right , 2 - middle , 3 - dop
        {
            _character.transform.eulerAngles = new Vector3(0,_angleX,0);
        }
        /*_character.transform.forward // изменение движения (пинок в ету сторону) */
        this.transform.eulerAngles = new Vector3(_angleY,_angleX,0);
    }
}
