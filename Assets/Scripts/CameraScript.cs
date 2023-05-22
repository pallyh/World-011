using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject _character;  //������ �� ������ ��������
    private Vector3 _offset;        //�������� ������� � ���������
    private float _angleX;          //����������� ���� �������� �� X �������
    private float _angleY;          //����������� ���� �������� �� Y �������
    private float _sensX = 450;     //��������������� ��������� �� X �������
    private float _sensY = 200;     //��������������� ��������� �� Y �������

    void Start()
    {
        _character = GameObject.Find("Character"); //����� �� ����� ������� � �����
        _offset = this.transform.position - _character.transform.position;
        _angleX = 0;
        _angleY = this.transform.eulerAngles.x; //�������� �� � = �������� �� �
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
        /*_character.transform.forward // ��������� �������� (����� � ��� �������) */
        this.transform.eulerAngles = new Vector3(_angleY,_angleX,0);
    }
}
