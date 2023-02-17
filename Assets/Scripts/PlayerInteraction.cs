using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    private IUsable _target;
    private RaycastHit _rayHit;
    private GameObject _touched;
    [SerializeField] private Image _crossHairImg;
    private bool _hit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
        UseTarget();
        ChangeCrossHairState();
    }

    private void FindTarget()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _rayHit, _maxDistance))
        {
            if (_rayHit.collider.gameObject != null)
            {
                _touched = _rayHit.collider.gameObject;
                if (!_hit) _hit = true;
            }
        }
        else
        {
            _touched = null;
            if (_hit) _hit = false;
        } 
        if (_touched != null && _touched.GetComponent<IUsable>() != null) { _target = _touched.GetComponent<IUsable>(); _hit = true; }
        else {_target = null; _hit = false;}
    }

    private void UseTarget()
    {
        if (Input.GetButtonDown("Fire1") && _target!=null) _target.Use();
    }

    private void ChangeCrossHairState()
    {
        if (_hit) _crossHairImg.color = Color.red;
        else _crossHairImg.color = Color.white;
    }

}
