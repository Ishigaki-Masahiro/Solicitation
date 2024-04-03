using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Item item = default;
    [SerializeField] Image image = default;
    [SerializeField] GameObject backgroundPanel = default;

    private void Awake()
    {
        //image = GetComponent<Image>(); //image��Image�R���|�[�l���g������
    }

    //�A�C�e���X���b�g���󂩂ǂ����̔��f
    public bool IsEmpty()
    {
        if (item == null)
        {
            return true;
        }
        return false;
    }


    //ItemBox�X�N���v�g��SetItem�֐��Ŏ��s
    public void SetItem(Item item)
    {
        this.item = item;
        UpdateImage(item);
    }


    //ItemBox�X�N���v�g��TryUseItem�֐��Ŏ��s
    public Item GetItem()
    {
        return item;
    }


    // �A�C�e�����󂯎������摜���X���b�g�ɕ\�����Ă��
    void UpdateImage(Item item)
    {
        if (item == null) //�����A�C�e�����Ȃ��Ȃ�
        {
            image.sprite = null; //�摜����������Ȃ�
        }
        else
        {
            image.sprite = item.sprite;�@//Slot��image�ɃN���b�N�����A�C�e����sprite������
        }
    }


    //�I���������̔w�i�p�l����\������֐��@����ItemBox�X�N���v�g��OnSelectSlot�֐��Ŏg�p
    public bool OnSelected()
    {
        if (item == null) //�@�A�C�e���������Ă��Ȃ��ꍇ
        {
            return false; //�I���͎��s
        }

        backgroundPanel.SetActive(true); //�w�i�摜�p�l����\������
        return true; //�I�𐬌�
    }


    //�I���������̔w�i�p�l���������֐��@����ItemBox�X�N���v�g��OnSelectSlot�֐��Ŏg�p
    public void HideBgPanel()
    {
        backgroundPanel.SetActive(false);
    }
}