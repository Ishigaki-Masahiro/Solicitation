using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] ItemListEntity ItemListEntity = default;

    //Item��type���琶������
    public Item spawn(Item.Type type)
    {
        for (int i = 0; i < ItemListEntity.itemList.Count; i++)
        {
            Item itemData = ItemListEntity.itemList[i];

            //�f�[�^�x�[�X�̒�����type����v������̂�T��
            if (itemData.type == type)
            {
                //��v������AItem�𐶐����ēn��
                return new Item(itemData.type,itemData.sprite);
            }
        }
        return null;
    }
}