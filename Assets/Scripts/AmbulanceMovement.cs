using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceMovement : MonoBehaviour
{
    [SerializeField] private float _speed, _maxDistance, _minDistance;
    private bool _isFacingNorth;
    private Rigidbody _rb;
    private Vector3 _direction, _initialPos;
    

    private void Awake()
    {
        _rb= gameObject.GetComponent<Rigidbody>();
        _direction = new Vector3(-1,0,0) ;
        _initialPos= transform.position;
        _isFacingNorth = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void PushForward()
    {
        _rb.velocity = _direction* _speed * Time.fixedDeltaTime;
    }

    private void Movement()
    {
        if (_isFacingNorth)
        {
            _direction = new Vector3(-1,0,0);
            if (Vector3.Distance(_initialPos, transform.position) >= _maxDistance) _isFacingNorth = false;
        }
        else
        {
            _direction = new Vector3(1, 0, 0);
            if (Vector3.Distance(_initialPos, transform.position) <= _minDistance) _isFacingNorth = true;
        }
        PushForward();
        
    }

}
