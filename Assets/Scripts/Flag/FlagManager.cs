// File path: Scripts/FlagManager.cs

using UnityEngine;

public class FlagManager : MonoBehaviour
{
    // Singleton�C���X�^���X
    public static FlagManager Instance { get; private set; }

    // �e�C�x���g�̏�Ԃ�\��Enum
    public enum EventStatus
    {
        NotStarted, // ���J�n
        InProgress, // �i�s��
        Completed   // ����
    }

    // �v�����[�O�C�x���g
    public EventStatus Prologue_Start { get; private set; }

    // 1���ڂ̃C�x���g
    public EventStatus Day1_UnpackingStart { get; private set; }
    public EventStatus Day1_Visitor { get; private set; }
    public EventStatus Day1_MailDelivery { get; private set; }
    public EventStatus Day1_ReligionFlyerDelivery { get; private set; }
    public EventStatus Day1_UnpackingEnd { get; private set; }

    // 2���ڂ̃C�x���g
    public EventStatus Day2_Visitor1 { get; private set; }
    public EventStatus Day2_UnpackingStart { get; private set; }
    public EventStatus Day2_Visitor2 { get; private set; }
    public EventStatus Day2_ReadBook { get; private set; }

    // 3���ڂ̃C�x���g
    public EventStatus Day3_Visitor1 { get; private set; }
    public EventStatus Day3_Visitor2 { get; private set; }
    public EventStatus Day3_UnpackingEnd { get; private set; }
    public EventStatus Day3_Visitor3 { get; private set; }
    public EventStatus Day3_Visitor4 { get; private set; }
    public EventStatus Day3_FriendLeaves { get; private set; }
    public EventStatus Day3_AirConditionerBroken { get; private set; }

    // 4���ڂ̃C�x���g
    public EventStatus Day4_Visitor1 { get; private set; }
    public EventStatus Day4_Visitor2 { get; private set; }
    public EventStatus Day4_Visitor3 { get; private set; }
    public EventStatus Day4_ChoiceSuccess { get; private set; }
    public EventStatus Day4_ChoiceFailure { get; private set; }

    private void Awake()
    {
        // Singleton�p�^�[���̎���
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // �C�x���g�̏�Ԃ�ݒ肷�郁�\�b�h
    public void SetEventStatus(string eventName, EventStatus status)
    {
        GetType().GetProperty(eventName).SetValue(this, status);
    }

    // �C�x���g�̏�Ԃ��擾���郁�\�b�h
    public EventStatus GetEventStatus(string eventName)
    {
        return (EventStatus)GetType().GetProperty(eventName).GetValue(this);
    }

    // �S�ẴC�x���g��Ԃ����Z�b�g���郁�\�b�h
    public void ResetAllFlags()
    {
        foreach (var prop in GetType().GetProperties())
        {
            if (prop.PropertyType == typeof(EventStatus))
            {
                prop.SetValue(this, EventStatus.NotStarted);
            }
        }
    }
}