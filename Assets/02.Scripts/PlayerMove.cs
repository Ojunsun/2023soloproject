using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 8f;
   
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

    [HideInInspector] public StaminaController _staminaController;
    [HideInInspector] bool isWalk = true;

    private void Start()
    {
        _staminaController = GetComponent<StaminaController>();
        myRigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(); // �÷��̾� ������
        Run();
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

    private void Run()
    {
        isWalk = !Input.GetKey(KeyCode.LeftShift);

        if(isWalk)
        {
            _staminaController.isSprinting = false;
        }

        if (_staminaController.playerStamina > 0 && !isWalk)
        {
            _staminaController.isSprinting = true;
            _staminaController.Sprinting();
            speed = 15f;

            if (_staminaController.isCanRun == false)
            {
                speed = 10f;
            }
        }
        else
        {
            _staminaController.isSprinting = false;
            speed = 10f;
        }
    }
}
