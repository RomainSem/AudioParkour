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
            _target = hit.collider.GetComponent<IUsable>();
        }
        else
        {
            _target = null;
        }
    }

    void UseTarget()
    {
        if (Input.GetButtonDown("Use"))
        {
            _target.Use();
        }
    }

    public void ChangeCrossHairState()
    {
        if (_target != null)
        {
            _crosshair.color = Color.blue;
        }
        else
        {
            _crosshair.color = Color.white;
            Debug.Log("raycast");
        }
    }

    #endregion

    #region Private & Protected

    IUsable _target;

    #endregion
}
