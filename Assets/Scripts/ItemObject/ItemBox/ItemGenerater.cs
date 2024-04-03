using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    [SerializeField] ItemListEntity itemListEntity = default;

    // �ǂ��ł����s�ł�����
    public static ItemGenerater instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // PickupObj�X�N���v�g��start�֐��Ŏ��s����
    public Item Spawn(Item.Type type)
    {
        // itemList�̒�����type�ƈ�v�����瓯��item(�f�[�^)�𐶐����ēn��
        foreach (Item item in itemListEntity.itemList)
        {
            if (item.type == type)
            {
                return new Item(item.type, item.sprite);
            }
        }
        return null;
    }
}