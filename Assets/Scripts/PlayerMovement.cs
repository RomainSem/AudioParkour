using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Exposed

    [SerializeField] float _normalSpeed = 5f;
    [SerializeField] float _sprintSpeed = 10f;
    


    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _footSteps = GameObject.Find("FootSteps").GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;
        Vector3 move;

        _footSteps.pitch = _characterController.velocity.magnitude / _normalSpeed;

        if (Input.GetButton("Sprint"))
        {
            move = direction * _sprintSpeed * Time.deltaTime;
        }
        else
        {
            move = direction * _normalSpeed *Time.deltaTime;
        }
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
    AudioSource _footSteps;

    #endregion
}
