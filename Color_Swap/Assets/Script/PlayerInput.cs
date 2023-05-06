using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Camera _camera;
    public delegate Vector3 MousePosition();
    public MousePosition GetMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        GetMousePosition += MovementControl;
    }
    Vector3 MovementControl()
    {
       // var Pos = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
        var Pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(Pos.x,Pos.y, 0);
    }

}
