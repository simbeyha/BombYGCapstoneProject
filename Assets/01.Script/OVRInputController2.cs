using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// ��Ʈ�ѷ��� �浹�� �ٸ� ������Ʈ�� ��Ʈ�ѷ��� ���ӽ�Ű�� ��� (��ġ, ȸ�� = TRansform)
// ��Ʈ�ѷ��� 3D ������Ʈ�� ��� ���

public class OVRInputController : MonoBehaviour
{
    //����, ������ ��Ʈ�ѷ��� �����ϴ� ����
    public OVRInput.Controller controller;

    // OVR CameraRig
    public Transform player;

    // Hand Anchor�� Transform�� Rigidbody
    private Transform handTransform = null;
    private Rigidbody handRigidbody = null;

    // �浹ü�� Rigidbody �����ϴ� ����
    private Rigidbody attachedObject = null;

    //�浹�� �浹ü���� Rigidbody�� �����ϴ� ����
    private List<Rigidbody> contactRigidbodies = new List<Rigidbody>();

    void Start()
    {
        handTransform = GetComponent<Transform>();
        handRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // �׸� ��ư�� ������ ��, Pickup(������Ʈ�� ��Ʈ�ѷ��� ��� ���)�� ����ǵ���
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            ObjectPickup();
        }

        // �׸� ��ư�� ������ ��, Drop(��Ʈ�ѷ��� ������ ������Ʈ�� ���� ���)�� ����ǵ���
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            ObjectDrop();
        }


    }

    // ��Ʈ�ѷ��� 3D ������Ʈ�� ��� ���
    public void ObjectPickup()
    {
        attachedObject = GetNearestRigidbody();

        // attachedObject�� �ִٸ� ������Ʈ�� ��Ʈ�ѷ��� ���ӽ�Ű�� ��� ����
        if (attachedObject == null)
            return;
        
        // ��ü�� ��Ʈ�ѷ��� ���ӽ�ų ��, �߷��� ��Ȱ��ȭ
        attachedObject.useGravity = false;

        // [�ɼ�] ����ȿ���� ��Ȱ��ȭ
        attachedObject.isKinematic = true;


        attachedObject.transform.parent = handTransform; // �浹�� ������Ʈ�� �θ� ������Ʈ�� ��Ʈ�ѷ� ���� (����&���ϵ�ȭ)
        attachedObject.transform.position = handTransform.position; //�浹�� ������Ʈ�� ��ġ �ʱ�ȭ
        attachedObject.transform.rotation = handTransform.rotation; //�浹�� ������Ʈ�� ȸ�� �ʱ�ȭ
    }

    //��Ʈ�ѷ��� �浹�� ������Ʈ �� ���� ����� �Ÿ��� �ִ� ������Ʈ�� Rigidbody�� �����ϴ� ���
    private Rigidbody GetNearestRigidbody()
    {
        //Rigidbody�� �����ϴ� �ӽ� ����
        Rigidbody nearestRigidbody = null;

        //��Ʈ�ѷ��� �浹ü ���� �Ÿ�(Distance) ���� �����ϴ� ���� (�ּ� ��)
        float minDistance = float.MaxValue;

        // ���� �Ÿ�(Distance) ���� �����ϴ� ����
        float distance = 0;

        //List�� ����� Rigidbody �� ���� ����� Rigidbody�� �Ǻ��ϴ� ���
        foreach (Rigidbody rigidbody in contactRigidbodies) 
        {
            //List�� ����� Rigidbody �� ����� Rigidbody�� ���
            //rigidbody �浹ü�� ��ġ�� handTransform(��Ʈ�ѷ�)�� ������ �Ÿ��� ���
            distance = Vector3.Distance(rigidbody.transform.position, handTransform.position);


            // ���� distance�� minDistance�� ��
            if (distance > minDistance)
            {
                //�ּ� �Ÿ� ���� ����
                minDistance = distance;

                //��ȯ�� ���� ����� Rigidbody ��ü�� ����
                nearestRigidbody = rigidbody;

            }


        }

        return nearestRigidbody;
    }



    // ��Ʈ�ѷ��� ������ 3D ������Ʈ�� ���� ���
    public void ObjectDrop()
    {
        // ��Ʈ�ѷ��� ���ӵ� ������Ʈ�� �ִٸ� ������Ʈ�� ��Ʈ�ѷ����� ������ �����ϴ� ��� ����
        if (attachedObject == null)
            return;

        // ��ü�� ��Ʈ�ѷ��� ���ӽ�ų ��, �߷��� Ȱ��ȭ
        attachedObject.useGravity = true;

        // [�ɼ�] ����ȿ���� Ȱ��ȭ
        attachedObject.isKinematic = false;

        attachedObject.transform.parent = null; // �浹�� ������Ʈ�� �θ� ������Ʈ�� ����� ���� (���ϵ�ȭ ����)

        // ��Ʈ�ѷ����� �������� ���ÿ� ��Ʈ�ѷ��� ������ �ִ� ���� �������� �������ִ� ���
        attachedObject.velocity += player.rotation * OVRInput.GetLocalControllerVelocity(controller);
        attachedObject.angularVelocity += player.rotation * OVRInput.GetLocalControllerAngularVelocity(controller);

        attachedObject = null;

    }

    // ��Ʈ�ѷ��� 3D ������Ʈ�� �����ϴ� ����
    // 1. ��Ʈ�ѷ��� ��ư(Grip)�� ������ (Input)
    // 2. �浹�� �����ؾ� �Ѵ� (Collider, Rigidbody)
    // 3. �浹ü ���� �浹�� �Ͼ�� �Ѵ� (OnCollision~, OnTrigger)

    private void OnTriggerEnter(Collider other)
    {
        // ��Ʈ�ѷ��� ���� ������Ʈ�� �±װ� InteractionObject ��� attachedObject�� �浹ü�� ����
        if (other.CompareTag("InteractionObject"))
        {
            // ��Ʈ�ѷ��� ���� �浹ü�� ���� ���
            //attachedObject = other.gameObject.GetComponent<Rigidbody>();

            // List �迭�� �浹ü�� ����
            contactRigidbodies.Add(other.gameObject.GetComponent<Rigidbody>());
        }



    }

    private void OnTriggerExit(Collider other)
    {
        // ��Ʈ�ѷ����� ������ ������Ʈ�� �±װ� InteractionObject ��� List���� ����
        if (other.CompareTag("InteractionObject"))
        {
            //��Ʈ�ѷ��� ������Ʈ�� �浹�� ������ ��
            //attachedObject = null;

            //List �迭���� �浹ü�� ����
            contactRigidbodies.Remove(other.gameObject.GetComponent<Rigidbody>());
        }

    }
}
