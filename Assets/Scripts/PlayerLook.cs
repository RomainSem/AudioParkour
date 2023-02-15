using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    #region Expose

    
    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {
        
    }

    void Start()
    {

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float gamePadX = Input.GetAxis("RightHorizontal");
        float gamePadY = Input.GetAxis("RightVertical");
        mouseX = _mouseSensitivity.x * Time.deltaTime;
        mouseY = _mouseSensitivity.y * Time.deltaTime;
        gamePadX = _padSensitivity.x * Time.deltaTime;
        gamePadY = _padSensitivity.y * Time.deltaTime;
        _horizontal += mouseX + gamePadX;
        _vertical += mouseY + gamePadY;
    }


    #endregion

    #region Methods


    #endregion

    #region Private & Protected

    Vector2 _mouseSensitivity, _padSensitivity, _mouseYLimit;
    float _horizontal, _vertical;

    #endregion
}
