using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRInputManager : MonoBehaviour
{
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }




    private void ControllerInput()
    {
        //OVRInput�� �ֿ� �뵵�� Get(), GetDown(), GetUp() �Լ��� ���� ��Ʈ�ѷ��� �Է� ���¿� ������ �ϴ� ��
        // Get(): ��Ʈ�ѷ��� ���� �������� �Է� ���¸� ���� (�� �����Ӹ��� �ݺ�)
        // GetDown(): ���� �������� ��Ʈ�ѷ��� ���ȴ����� ����
        // GetUp(): ���� �������� ��Ʈ�ѷ��� ���������� ����

        // ��Ʈ�ѷ��� �Է°��� �޾ƿ��� ���
        // ex) OVRInput.Get~(OVRInput.Button.[��ư �̸�].[��Ʈ�ѷ�])

        // OVRInput.Button : �е�, ��ġ, �� �� ��Ʈ�ѷ��� ��� ������ ��ư (���ȴ�, �ȴ��ȴ�) = Boolean
        // OVRInput.Touch : ��Ʈ�ѷ��� ��ġ ���� ��ư = Boolean
        // OVRInput.NearTouch : ������ ���� ���� ��Ʈ�ѷ��� ������� ���� ��������� ���� = Boolean
        // OVRInput.Axis1D : �Ǽ�(float)�� ��ȯ�ϴ� 1���� ��Ʈ�� (Ʈ���� ��ư)
        // OVRInput.Axis2D : Vector2 ���� ��ȯ�ϴ� 2���� ��Ʈ�� (���̽�ƽ)

        // �Է� ���� ���
        // 1.Vitual Mapping (Combined Controller : ���յ� ��Ʈ�ѷ� �׼���)
        // ���յ� ��Ʈ�ѷ��� �׼����Ͽ� ������ �տ� ���� ������ �����ϴ� ���
        // �޼հ� �����տ� ��ư �̸��� ������ �и��Ǿ� �־� �����ϱ� ������, ������ ��Ʈ�ѷ��� �νĵǾ��� �� ���� ��Ʈ�ѷ��� �Է°��� �۵���

        // ������ Ʈ���� ��ư�� ������ ��
        //if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        //{
        //    Debug.Log("������ Ʈ���� ��ư");
        //}

        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        //{
        //    Debug.Log("���� Ʈ���� ��ư");
        //}

        //2. Virtual Mapping (Individual Controller : ���� ��Ʈ�ѷ� �׼���)
        // ������ ��Ʈ�ѷ��� ���������� �׼����Ͽ� ���ε��ϴ� ��� (LTouch or RTouch)
        // ���� �׼����̱� ������ ��Ʈ�ѷ� �νĳ���� ������ ������ ����, ������ ��Ʈ�ѷ��� ���� �ڵ带 �ۼ��ؾ� ��

        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        //{
        //    Debug.Log("������ Ʈ���� ��ư");
        //}

        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        //{
        //    Debug.Log("���� Ʈ���� ��ư");
        //}

        //3. Raw Mapping ���� ����
        // ��Ʈ�ѷ��� ���� �����Ͽ� �����ϴ� ���
        // ������ ��Ʈ�ѷ��� ��ư���� ���� ������ ���ε��Ͽ� ����ϴ� ���

        //if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        //{

        //}

    }
}
