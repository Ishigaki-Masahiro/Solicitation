using System.Collections.Generic;
using UnityEngine;

public class SceneFlagManager : MonoBehaviour
{
    public static SceneFlagManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [Header("SaveFlag")]
    public bool isSaving;

    [Header("LoadFlag")]
    public bool isLoading;

    [Header("�v���C���[MoveFlag")]
    public bool isPlayerMoving;

    [Header("��b�p�[�gFlag")]
    public bool isTaking;

    [Header("Debug�p���Ԃ��~�߂�Flag")]
    public bool isStopTime;

    [Header("�ݒ��ʂ��\������Ă����ꍇ��Ray���΂��Ȃ�Flag")]
    public bool isSetting;

    [Header("SceneFlagManager�̃Q�[�����@�\��L���ɂ��邩���Ȃ���")]
    public bool isActive;

    [Header("Lists")]
    public List<Sun> sunLists = new List<Sun>();

}

[System.Serializable]
public class Sun
{
    public enum SUN
    {
        AGE_1,
        AGE_2,
        AGE_3,
        AGE_4,
        AGE_5,
    }

    [Header("Tag")]
    public SUN sun;

    [Header("�����ڂ�")]
    public bool isAGE; // �����Ƃ�isAGE���

    // �e���ɈقȂ镔���ɕω����N�����t���O�̃��X�g
    [Header("�����ɕω����N�����t���O")]
    public List<RoomFlag> roomFlags = new List<RoomFlag>();
}

[System.Serializable]
public class RoomFlag
{
    [Header("�����ٕ̈ς��N�����t���O")]
    public bool isActive;
}