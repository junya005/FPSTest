using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb = null;

    [SerializeField]
    private float _speed = 100;

    [SerializeField]
    private bool _isJump = false;

    [SerializeField]
    private float _jumpForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float Xaxis = Input.GetAxis("Horizontal");
        float Zaxis = Input.GetAxis("Vertical");

        _rb.AddForce((transform.forward*Zaxis + transform.right*Xaxis)*_speed);

        if(_isJump && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
            _isJump = false;
        }

        LimitVelocity();

        Debug.Log(_rb.velocity);
    }

    private void LimitVelocity()
    {
        if(_rb.velocity.x > 10.0f)
        {
            _rb.velocity = new Vector3(10.0f, _rb.velocity.y, _rb.velocity.z);
        }

        if(_rb.velocity.z > 10.0f)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, 10.0f);
        }
        if(_rb.velocity.x < -10.0f)
        {
            _rb.velocity = new Vector3(-10.0f, _rb.velocity.y, _rb.velocity.z);
        }

        if(_rb.velocity.z < -10.0f)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, -10.0f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            _isJump = true;
        }
    }
}
