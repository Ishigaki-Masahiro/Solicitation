using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemLogger
{
    static List<string> parts = new List<string>();
    //���X�g���̐���int�ŏ����o����
    //if�����Ŏg����
    public static int Count => parts.Count;

    public static void Clear()
    {
        parts.Clear();
        //�A�C�e�������N���A
    }

    public static void Add(string GetitemID)
    {
        if (Contains(GetitemID))
        {
            //�擾��Ԃ͒ǉ�����^�C�~���O�ł��`�F�b�N!
            return;
        }
        parts.Add(GetitemID);
        //�Q�b�g�����A�C�e�����L�^
    }

    //�A�C�e�����Q�b�g�������m�F
    public static bool Contains(string CheckItemID)
    {
        return parts.Contains(CheckItemID);
    }
}