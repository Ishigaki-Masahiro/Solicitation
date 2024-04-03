using System;
using UnityEngine;

[Serializable] // �C���X�y�N�^�[�ŕ\�������
public class Item
{
    // ��ނ������Ă���
    public enum Type
    {
        Card_1,
        Card_2,
        Card_3,
        Card_4,
        Card_5,
        Card_6,
    }
    public Type type;     // ���
    public Sprite sprite; // Slot�ɕ\������摜

    public Item(Type type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }
}