using UnityEngine;

public class ItemProperty : MonoBehaviour
{
    [TextArea]
    public string itemCommentry;

    public string itemName; //������ �̸�

    public Sprite itemImage;// ������ �̹���

    public ItemType itemType; //������ ����

    public bool isHit;
    public enum ItemType
    {
        Food,
        Water,
        Thing
    }

    public void OnText() => gameObject.transform.GetChild(0).gameObject.SetActive(true);    //�ش� ���� ������Ʈ�� ù��° �ڽ��� Ȱ��ȭ
    public void OffText() => gameObject.transform.GetChild(0).gameObject.SetActive(false);
    void Start()
    {
        //Age = 10;
        //Debug.Log(Age);
    }
}










//  public GameObject itemPre; //�������� ������

//public string ItemName
//{
//    get { return itemName; }
//    set { itemName = value; }
//}

//public Sprite ItemImage
//{
//    get { return itemImage; }
//    set
//    {
//        if (value != itemImage)
//        {
//            itemImage = value;
//        } else
//        {
//            return;
//        }
//    }
//}

//public int Age { get; set; }



//public string 