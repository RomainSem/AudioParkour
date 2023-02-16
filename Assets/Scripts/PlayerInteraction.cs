using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    #region Exposed

    [SerializeField] float _maxDistance;
    [SerializeField] Image _crosshair;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        FindTarget();
        UseTarget();
        ChangeCrossHairState();
    }

    private void FixedUpdate()
    {
        
    }

    #endregion

    #region Methods

    void FindTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _maxDistance))
        {
            if (hit.collider.gameObject.tag == "Bouton")
            {
                _target = hit.collider.gameObject.GetComponent<IUsable>();
            }
            else
            {
                _target = null;
            }
        }
    }

    void UseTarget()
    {
        if (Input.GetButtonDown("Use"))
        {
            _target.Use();
        }
    }

    void ChangeCrossHairState()
    {
        if (_target != null)
        {
            _crosshair.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            _crosshair.GetComponent<Image>().color = Color.white;
        }
    }
    
    #endregion

    #region Private & Protected

    IUsable _target;

    #endregion
}
