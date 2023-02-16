using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Exposed

    [SerializeField] float _speed = 5f;
    


    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;
        Vector3 move = direction * _speed * Time.deltaTime;
        _characterController.Move(move);
    }

    private void FixedUpdate()
    {
        
    }

    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    CharacterController _characterController;

    #endregion
}
