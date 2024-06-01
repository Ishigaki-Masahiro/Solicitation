using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solicitation : MonoBehaviour
{
    // FlagManager�ւ̎Q��
    private FlagManager flagManager;

    private void Start()
    {
        // FlagManager�̃C���X�^���X���擾
        flagManager = FlagManager.Instance;

        if (flagManager == null)
        {
            Debug.LogError("FlagManager instance is null. Make sure FlagManager is initialized before using Solicitation.");
        }
    }

    // �S�ẴC�x���g��Ԃ����Z�b�g���郁�\�b�h
    public void ResetAllEventFlags()
    {
        if (flagManager != null)
        {
            flagManager.ResetAllFlags();
        }
    }

    // �C�x���g�̏�Ԃ�ݒ肷�郁�\�b�h
    public void SetEventStatus(string eventName, FlagManager.EventStatus status)
    {
        if (flagManager != null)
        {
            flagManager.SetEventStatus(eventName, status);
        }
    }

    // �C�x���g�̏�Ԃ��擾���郁�\�b�h
    public FlagManager.EventStatus GetEventStatus(string eventName)
    {
        if (flagManager != null)
        {
            return flagManager.GetEventStatus(eventName);
        }

        return default;
    }
}