using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCameraController : MonoBehaviour
{
    [SerializeField] Joystick rotateJoystick;

    private float mouseX;
    private float mouseY;

    private float eulerX;
    private float eulerY;

    [Header("���������������� ����")]
    public float _sensivityMouse = 100f;

    public Transform Player;
    public Transform Camera;

    private float xRot;
    private float yRot;

    private Quaternion startCameraRotation;

    void Start()
    {
        startCameraRotation = Player.transform.localRotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //��������� ������������ ���������� ���������
        float mY = rotateJoystick.Vertical * _sensivityMouse * Time.deltaTime;
        //��������� ��������� ��� � - �����-���� (���� "-" ����������� ����������)
        xRot -= mY;
        //������������ ���� �������� � ������������� ��������
        //� ������ �������������� ����������� ������ ����������
        //-30f - ������ ���������� �����
        //30f - ������ ���������� ����
        xRot = Mathf.Clamp(xRot, -30f, 30f);
        //������������ ������ �� ���������� ���� ��������
        Camera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        //��������� �������������� ���������� ���������
        float mX = rotateJoystick.Horizontal * _sensivityMouse * Time.deltaTime;
        //��������� ��������� ��� Y - �����-������
        yRot += mX;
        //������������ ���� �������� � ������������� ��������
        //yRot = Mathf.Clamp(yRot, -360f, 360f);
        //������������ ������ �� ���������� ���� ��������
        //Player.transform.Rotate(Vector3.up * mX);
        Player.transform.localRotation = Quaternion.Euler(0f, yRot, 0f);
        
    }

    public void ResetPosition()
    {
         Player.transform.rotation = new Quaternion(0f,0f,0f,0f);
    }

}
