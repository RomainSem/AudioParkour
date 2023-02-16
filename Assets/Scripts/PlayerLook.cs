using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    #region Expose

    [SerializeField] Vector2 _mouseSensitivity;
    [SerializeField] Vector2 _padSensitivity;
    [SerializeField] Vector2 _mouseYLimit;

    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity.y * Time.deltaTime;
        float gamePadX = Input.GetAxis("RightHorizontal") * _padSensitivity.x * Time.deltaTime;
        float gamePadY = Input.GetAxis("RightVertical") * _padSensitivity.y * Time.deltaTime;
        _horizontal += mouseX /*+ gamePadX*/;
        _vertical += mouseY /*+ gamePadY*/;
        _vertical = Mathf.Clamp(_vertical, _mouseYLimit.x, _mouseYLimit.y);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _horizontal, transform.eulerAngles.z);
        _cameraTransform.eulerAngles = new Vector3(_vertical, _cameraTransform.eulerAngles.y, _cameraTransform.eulerAngles.z);
    }


    #endregion

    #region Methods


    #endregion

    #region Private & Protected

    
    float _horizontal, _vertical;
    Transform _cameraTransform;

    #endregion
}
