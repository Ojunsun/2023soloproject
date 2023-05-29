using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 10f;

    float hAxis;
    float vAxis;

    private Rigidbody myRigid;

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;

    private float currentCameraRotationX = 0f;
    private float currentCameraRotationY = 0f;

    [SerializeField]
    private Camera theCamera;

    
    private void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(); // 플레이어 움직임
        PlayerRun();
    }

    private void Update()
    {
        CameraRotation(); //상하 카메라 회전
        CharacterRotation(); //좌우 캐릭터 회전
    }

    private void Move()
    { 
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(hAxis, 0, vAxis);
        dir = transform.rotation * dir.normalized;
        //transform.Translate(dir.normalized * speed * Time.deltaTime);
        myRigid.velocity = dir.normalized * speed;
    }

    private void PlayerRun()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }
    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _CameraRotationX = _xRotation * lookSensitivity; //마우스 가 바로 45도 이동이 아니라 천천히 이동시키게 함
        currentCameraRotationX -= _CameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);//최대값 최솟값 지정

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0); //각도를 바꿔준다.
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        float _characterRotationY = _yRotation * lookSensitivity;
        currentCameraRotationY += _characterRotationY;

        transform.localEulerAngles = new Vector3(0, currentCameraRotationY, 0);
    }
}
