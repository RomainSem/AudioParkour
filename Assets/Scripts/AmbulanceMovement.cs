using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceMovement : MonoBehaviour
{
    #region Expose

    [SerializeField] float _speed = 10f;
    [SerializeField] float _maxDistance = 50f;
    [SerializeField] float _minDistance = 10f;

    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource= GetComponentInChildren<AudioSource>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (_isFacingNorth)
        {
            if (transform.position.z < _minDistance)
            {
                UTurn();
            }
        }
        else
        {
            if (transform.position.z > _maxDistance)
            {
                UTurn();
            }

        }

        if (_rigidbody.velocity.magnitude > 0)
        {
            // Si l'objet est en mouvement, applique un effet Doppler à son son
            _audioSource.dopplerLevel = 1f;
        }
        else
        {
            // Si l'objet est immobile, désactive l'effet Doppler sur son son
            _audioSource.dopplerLevel = 0f;
        }
    }


    #endregion

    #region Methods

    private void PushForward()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void UTurn()
    {
        // On inverse le forward du transform en Z pour le retourner
        transform.forward = -transform.forward;
        // On inverse la valeur de la variable indiquant notre direction actuelle (aller 0 ou
        //retour 1)
        _isFacingNorth = !_isFacingNorth;
        // On fait demi-tour
        PushForward();
    }


    #endregion

    #region Private & Protected

    bool _isFacingNorth;
    Rigidbody _rigidbody;
    AudioSource _audioSource;

    #endregion
}
