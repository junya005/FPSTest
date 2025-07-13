using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POVController : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _body;
    [SerializeField] private float _sensX = 5f;
    [SerializeField] private float _sensY = 5f;
    private float _yRotation, _xRotation;

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X") * _sensX,
            Input.GetAxis("Mouse Y") * _sensY);

        _xRotation -= mouseInput.y;
        _yRotation += mouseInput.x;
        _yRotation %= 360; // 絶対値が大きくなりすぎないように

        // 上下の視点移動量をClamp
        _xRotation = Mathf.Clamp(_xRotation, -90, 70);

        // 頭、体の向きの適用
        _head.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _body.transform.localRotation = Quaternion.Euler(0, _yRotation, 0);
    }
}
