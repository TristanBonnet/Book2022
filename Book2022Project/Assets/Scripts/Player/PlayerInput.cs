using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    [SerializeField]
    private float _joystickLeftXRange = 0.5f;
    [SerializeField]
    private float _joystickLeftYRange = 0.5f;

    [SerializeField]
    private float _joystickRightXRange = 0.5f;
    [SerializeField]
    private float _joystickRightYRange = 0.5f;

    private float _joystickLeftXValue;
    private float _joystickLeftYValue;

    private float _joystickRightXValue;
    private float _joystickRightYValue;

    public float JoystickLeftXValue => _joystickLeftXValue;
    public float JoystickLeftYValue => _joystickLeftYValue;

    public float JoystickRightXValue => _joystickRightXValue;
    public float JoystickRightYValue => _joystickRightYValue;


    // Update is called once per frame
    void Update()
    {
        GetJoystickLeftXValue();
        GetJoystickLeftYValue();
        GetJoystickRightXValue();
        GetJoystickRightYValue();

        //Debug.Log(_joystickLeftXValue);
        //Debug.Log(_joystickLeftYValue);
    }


    private void GetJoystickLeftXValue()
    {

        _joystickLeftXValue = (Input.GetAxis("LeftJoystickX"));

        if (_joystickLeftXValue < _joystickLeftXRange)
        {
            if (_joystickLeftXValue > -_joystickLeftXRange)
            {

                _joystickLeftXValue = 0;
            }

            else
            {
                _joystickLeftXValue = -1;
            }
        }

        else
        {
            _joystickLeftXValue = 1;
        }
    }

    private void GetJoystickLeftYValue()
    {

        _joystickLeftYValue = (Input.GetAxis("LeftJoystickY"));

        if (_joystickLeftYValue < _joystickLeftYRange)
        {
            if (_joystickLeftYValue > -_joystickLeftYRange)
            {
                _joystickLeftYValue = 0;
            }

            else
            {
                _joystickLeftYValue = -1;
            }
            
        }

        else
        {
            _joystickLeftYValue = 1;
        }



    }

    private void GetJoystickRightXValue()
    {

        _joystickRightXValue = (Input.GetAxis("RightJoystickX"));

        if (_joystickRightXValue < _joystickRightXRange)
        {
            if (_joystickRightXValue > -_joystickRightXRange)
            {

                _joystickRightXValue = 0;
            }

            else
            {
                _joystickRightXValue = -1;
            }
        }

        else
        {
            _joystickRightXValue = 1;
        }
    }

    private void GetJoystickRightYValue()
    {

        _joystickRightYValue = (Input.GetAxis("RightJoystickY"));

        if (_joystickRightYValue < _joystickRightYRange)
        {
            if (_joystickRightYValue > -_joystickRightYRange)
            {

                _joystickRightYValue = 0;
            }

            else
            {
                _joystickRightYValue = -1;
            }
        }

        else
        {
            _joystickRightYValue = 1;
        }
    }



}
