using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJTalker : MonoBehaviour, IUsable
{

    #region Expose

    [SerializeField] AudioClip[] _audioClips;

    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {
        _audioSource= GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }


    #endregion

    #region Methods

    public void Use()
    {
        int randNb = Random.Range(0, _audioClips.Length);
        _audioSource.PlayOneShot(_audioClips[randNb]);
    }

    #endregion

    #region Private & Protected

    AudioSource _audioSource;

    #endregion
}
