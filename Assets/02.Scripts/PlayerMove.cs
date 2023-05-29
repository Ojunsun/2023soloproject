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
        Move(); // �÷��̾� ������
        PlayerRun();
    }

    private void Update()
    {
        CameraRotation(); //���� ī�޶� ȸ��
        CharacterRotation(); //�¿� ĳ���� ȸ��
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
        float _CameraRotationX = _xRotation * lookSensitivity; //���콺 �� �ٷ� 45�� �̵��� �ƴ϶� õõ�� �̵���Ű�� ��
        currentCameraRotationX -= _CameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);//�ִ밪 �ּڰ� ����

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0); //������ �ٲ��ش�.
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        float _characterRotationY = _yRotation * lookSensitivity;
        currentCameraRotationY += _characterRotationY;

        transform.localEulerAngles = new Vector3(0, currentCameraRotationY, 0);
    }
}
