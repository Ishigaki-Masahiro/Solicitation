using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] Slot[] slots = default;

    Slot selectedSlot = null;

    // �ǂ��ł����s�ł�����
    public static ItemBox instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // slots��slot�v�f���R�[�h���炢�����@
            slots = GetComponentsInChildren<Slot>();
        }
    }


    // PickupObj���N���b�N���ꂽ��A�X���b�g�ɃA�C�e���������
    public void SetItem(Item item)
    {
        foreach (Slot slot in slots) // slots�̐������J��Ԃ�
        {
            if (slot.IsEmpty()) //slot�������󂾂����ꍇ
            {
                slot.SetItem(item); //slot�ɃA�C�e��������
                break;              //��̃X���b�g�ɃA�C�e������ꂽ��J��Ԃ����~�߂�
            }
        }
    }


    //�X���b�g���I�����ꂽ���Ɏ��s����֐�
    public void OnSelectSlot(int position)
    {
        //��U�S�ẴX���b�g�̑I���p�l�����\���ɂ���
        foreach (Slot slot in slots) //slots�̐������J��Ԃ�
        {
            slot.HideBgPanel();
        }
        //�I�����ꂽ�X���b�g�̑I���p�l����\������
        if (slots[position].OnSelected()) // �����A�C�e���̑I�������������Ȃ�
        {
            selectedSlot = slots[position]; //�I�����Ă���X���b�g�̔ԍ���ϐ��ɓ����
        }
    }


    //�A�C�e���̎g�p�����݂違�g����Ȃ�g���Ă��܂�
    public bool TryUseItem(Item.Type type)
    {
        //�I���X���b�g�����邩�ǂ���
        if (selectedSlot == null)
        {
            return false;
        }

        if (selectedSlot.GetItem().type == type)
        {
            selectedSlot.SetItem(null); // �g�����A�C�e��������
            selectedSlot.HideBgPanel(); // �I��w�i�摜������
            selectedSlot = null;        // �I��ł�X���b�g�̕ێ����Ȃ���
            return true;
        }
        return false;
    }
}