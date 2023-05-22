using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterScript : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;
    private Vector3 _moveVector;
    private float _moveSpeed = 900f;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }



    void Update()
    {
        float factor = _moveSpeed * Time.deltaTime;
        float ix = Input.GetAxis("Horizontal");
        float iy = Input.GetAxis("Vertical");
        /*_moveVector = new Vector3(ix, 0, iy);*/
        _moveVector = this.transform.forward * iy
            + this.transform.right * ix;

        if (_moveVector.magnitude > 1)
        {
            _moveVector = _moveVector.normalized;
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            _moveVector = this.transform.forward * iy
            + this.transform.right * ix;
            _moveSpeed = 1800f;
            factor = _moveSpeed * Time.deltaTime;
            _animator.SetInteger("MoveState", 3);
            Debug.Log("Shift:"+_moveSpeed);
        }
        else
        {
            _moveVector = this.transform.forward * iy
            + this.transform.right * ix;
            _moveSpeed = 900f;
            factor = _moveSpeed * Time.deltaTime;
            if (_moveVector.magnitude > _characterController.minMoveDistance)
            {
                _animator.SetInteger("MoveState", 1);
            }
            else
            {
                _animator.SetInteger("MoveState", 0);
            }
            Debug.Log("None Shift:"+_moveSpeed);
        }
        _moveVector *= factor;

        _characterController.SimpleMove(_moveVector);
    }
}
