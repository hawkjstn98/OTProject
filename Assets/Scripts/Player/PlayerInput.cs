using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerInput : MonoBehaviour
{
    public FixedJoystick LeftJoystick;
    public FixedButton JumpButton;
    public FixedTouchField SwipeCamera;
    protected PlayerController Controller;

    protected float CameraAngleX;
    protected float CameraAngleY;
    protected float CameraAngleSpeed = 0.2f;
    public float TouchSensitivity_x = 10f;
     public float TouchSensitivity_y = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<PlayerController>();
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    // Update is called once per frame
    void Update()
    {
        Controller.m_Jump = JumpButton.Pressed;
        Controller.HInput = LeftJoystick.Horizontal;
        Controller.VInput = LeftJoystick.Vertical;

        CameraAngleX += SwipeCamera.TouchDist.x * CameraAngleSpeed;
        CameraAngleY += SwipeCamera.TouchDist.y * CameraAngleSpeed;
        if(0f == SwipeCamera.TouchDist.x){
            CameraAngleX = 0f;
        }
        if(0f == SwipeCamera.TouchDist.y){
            CameraAngleY = 0f;
        }
        

        // Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngleX, Vector3.up) * new Vector3(0, 3, 6);
        // Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
        // Debug.Log("CameraAngleX :" + CameraAngleX);
        // Debug.Log("CameraAngleY :" + CameraAngleY);
    }

    public float GetAxisCustom(string axisName)
        {
            if("Mouse X" == axisName)
            {
                return CameraAngleX;
            }
            else if("Mouse Y" == axisName)
            {
                return CameraAngleY;
            }
 
            return 0;
        }
}
