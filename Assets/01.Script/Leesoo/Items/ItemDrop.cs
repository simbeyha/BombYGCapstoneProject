using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    List<TextProperty> itemToolTips;        //_itemToolTipTextPerent���� GetComponentsInChildrun�� ����
                                            //TextProperty�� List�� �����ϱ� ���� ���� (�߿�)

    [SerializeField]
    List<TMP_Text> textList;        //ItemDrop Class���� textList�� [0]�� itemName[1]�� TextCommentory��� (�߿�)

    [SerializeField]
    private GameObject _itemToolTipTextPerent;      //TextProperty Class�� ������ �ִ� ������Ʈ�� �����ϱ� ����
                                                    //������ ������Ʈ �θ� �����ϱ����� ����(�߿�)

    private bool isHit;

    [SerializeField]
    private GameObject inventory;   //�κ��丮

    [SerializeField]
    private float range; //���� ������ �ִ� �Ÿ�

    private bool pickupHow = false; //���� ���ɽ� false

    private RaycastHit hitinfo; //�浹ü ���� ����

    [SerializeField] //������ ���̾�� ����
    private LayerMask layerMask;

    [SerializeField]
    private ItemProperty lastHitItem = null;


    public List<ItemProperty> itemProperties; //������ ����

    private void Start()
    {
        itemProperties = new List<ItemProperty>();
        textList = new List<TMP_Text>();
        itemToolTips = new List<TextProperty>();
    }
    void Update()
    {
       
        Action();
    }

    private void Action()
    {

        CheckItem();
        if (Input.GetKeyDown(KeyCode.E))        //VR��Ʈ�ѷ� Ű�� �ٲ����
        {
            CanPickup();
        }

    }
    private void CanPickup()
    {
        if (pickupHow)
        {
            if (hitinfo.transform != null)
            {
                // Debug.Log("ȹ��");

                itemProperties.Add(hitinfo.transform.GetComponent<ItemProperty>()); //����ĳ��Ʈ�� ���� �浹�� ������Ʈ���� ItemProperty ������Ʈ�� �����ͼ� ����Ʈ�� �߰�
                hitinfo.transform.gameObject.SetActive(false);     
                InfoDisappear();
            }
        }
    }
    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitinfo, range, layerMask))
        {
            if (hitinfo.transform.tag == "Item")        //item �±׸� ������ �ִ� �͸� ����
            {
                //item������Ʈ�� itemProperty ��ũ��Ʈ�� ����


                _itemToolTipTextPerent = hitinfo.transform.parent.transform.GetChild(1).gameObject;     //����ĳ��Ʈ�� ���� �浹�� ������Ʈ�� �θ� ��������, �� �θ� ������Ʈ�� �ڽ� �߿��� �� ��° �ڽ��� ������
                itemToolTips = _itemToolTipTextPerent.GetComponentsInChildren<TextProperty>().ToList(); //�� ��° �ڽ� ������Ʈ �Ʒ��� �ִ� ��� TextProperty ������Ʈ�� �����ͼ� ����Ʈ�� ��ȯ

                for (int i = 0; i < itemToolTips.Count; i++)        //itemToolTips����Ʈ�� �ִ� ��� �Ӽ��� ������ �߰�
                {                                                   //ToolTipText ++
                    textList.Add(itemToolTips[i].ToolTipText);
                }
                IteminfoApeer(hitinfo.transform.GetComponent<ItemProperty>());
                lastHitItem = hitinfo.transform.GetComponent<ItemProperty>();

                lastHitItem.OnText();
                hitinfo.transform.GetComponent<Outline>().enabled=true; //��ũ��Ʈ ���� Ű��
                isHit = true;
                    
            }
        }
        else
        {
            InfoDisappear();        //
            if (lastHitItem != null)
            {
                lastHitItem.OffText();      //�������� ������ Text����
                lastHitItem.transform.GetComponent<Outline>().enabled = false;      // �������� ������ �ƿ����� ����
            }
            isHit = false;
        }

    }
    private void IteminfoApeer(ItemProperty item)
    {
        if (!isHit)
        {
           
            textList[0].text = item.itemName;       //Item Name�� ����
            textList[1].text = item.itemCommentry;  //�ι�°
            Debug.Log("�������̸� : " + item.itemName
                        + '\n' + "������Ÿ�� : " + item.itemType); //Consolâ Ȯ�ο�
        }

        pickupHow = true;

    }
    private void InfoDisappear()
    {
        pickupHow = false;
        
    }

}