using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemProperty> _itemProperties; //ItemDrop Ŭ������ �ִ� itemProperties�� ����

    public GameObject _inventory;

    public ItemDrop _itemDrop;

    private void Start()
    {
        _itemDrop = gameObject.transform.parent.GetComponent<ItemDrop>();
    }

    private void Update()
    {
        OnInventory();
    }
    void OnInventory()  //�κ��丮 Ű�� ����
    {
        if (Input.GetKeyDown(KeyCode.I))        
        {
            if (gameObject.transform.GetChild(0).gameObject.activeSelf)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                _itemProperties = _itemDrop.itemProperties;
                SlotSetting();
            }
        }
    }
    void SlotSetting()                  //������ ������ �ʱ�ȭ �ؼ� ������ ����
    {
        foreach (ItemProperty asd in _itemProperties)
        {
            for (int i = 0; i < _inventory.transform.childCount; i++)
            {
                if (_inventory.transform.GetChild(i).GetComponent<Slot>()._isGetItem)
                {                   
                    //Slot�� �����ۿ� �ִٸ�, �Ȱ��� �������̸� ī��Ʈ�� ������Ű�� �ƴϸ� ���� �������� �ݺ� 
                }
                else
                {
                    _inventory.transform.GetChild(i).GetComponent<Slot>().SlotSprite = asd.itemImage;
                    break;
                }          
            }
        }
    }
}
