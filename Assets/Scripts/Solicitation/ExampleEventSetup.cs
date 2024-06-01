using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExampleEventSetup : MonoBehaviour
{
    public bool isProlog;
    public bool isDay1;
    public bool isDay2;
    public bool isDay3;
    public bool isDay4;

    public bool isOpenEntrance;

    public bool isNomalEnd;
    public bool isBadEnd;

    public static UnityAction OnStartProlog;

    private Solicitation solicitation;

    private void Start()
    {
        solicitation = GetComponent<Solicitation>();

        OnStartProlog += StartProlog;
    }

    private void Update()
    {
        if (isProlog && !isDay1)
        {
            Day1Complete();
        }

        if (isProlog && !isDay2)
        {
            Day2Complete();
        }

        if (isProlog && !isDay3)
        {
            Day3Complete();
        }

        if (isProlog && !isDay4)
        {
            Day4Complete();
        }

        if(isDay4 && isNomalEnd)
        {
            NormalEnd();
        }
        else if(isDay4 && isBadEnd)
        {
            BadEnd();
        }
    }

    public void StartProlog()
    {
        StartCoroutine(PrologComplete());
    }

    private IEnumerator PrologComplete()
    {
        // �v�����[�O�C�x���g�𖢊J�n��Ԃɐݒ�
        solicitation.SetEventStatus("Prologue_Start", FlagManager.EventStatus.NotStarted);
        // �C�x���g�̏�Ԃ��擾���ĕ\��
        Debug.Log("�v�����[�O�J�n" + solicitation.GetEventStatus("Prologue_Start"));

        yield return new WaitForSeconds(1f);

        // �v�����[�O�C�x���g��i�s���ɐݒ�
        solicitation.SetEventStatus("Prologue_Start", FlagManager.EventStatus.InProgress);
        // �C�x���g�̏�Ԃ��擾���ĕ\��
        Debug.Log("�v�����[�O�J�n" + solicitation.GetEventStatus("Prologue_Start"));

        yield return new WaitForSeconds(1f);

        // �v�����[�O�C�x���g��������Ԃɐݒ�
        solicitation.SetEventStatus("Prologue_Start", FlagManager.EventStatus.Completed);
        // �C�x���g�̏�Ԃ��擾���ĕ\��
        Debug.Log("�v�����[�O�I��" + solicitation.GetEventStatus("Prologue_Start"));

        yield return new WaitForSeconds(1f);

        // Flag�A�g
        isProlog = true;
    }

    private void Day1Complete()
    {
        if (2 <= SceneFlagManager.Instance.isCardBoardOpened.Count)
        {

        }
        if (5 <= SceneFlagManager.Instance.isCardBoardOpened.Count)
        {

        }

        // 1���ڂ̃C�x���g�̐i�s��ݒ�
        if (6 <= SceneFlagManager.Instance.isCardBoardOpened.Count)
        {
            solicitation.SetEventStatus("Day1_UnpackingStart", FlagManager.EventStatus.Completed);
            // �C�x���g�̏�Ԃ��擾���ĕ\��
            Debug.Log("1����_�ו��̊J���I��" + solicitation.GetEventStatus("Day1_UnpackingStart"));

            // Flag�A�g
            isDay1 = true;
        }
        solicitation.SetEventStatus("Day1_Visitor", FlagManager.EventStatus.Completed);
        solicitation.SetEventStatus("Day1_MailDelivery", FlagManager.EventStatus.Completed);
        solicitation.SetEventStatus("Day1_ReligionFlyerDelivery", FlagManager.EventStatus.Completed);
        solicitation.SetEventStatus("Day1_UnpackingEnd", FlagManager.EventStatus.Completed);
    }

    private void Day2Complete()
    {
        // 2���ڂ̃C�x���g�̐i�s��ݒ�
        solicitation.SetEventStatus("Day2_Visitor1", FlagManager.EventStatus.Completed);

        if (8 <= SceneFlagManager.Instance.isCardBoardOpened.Count)
        {
            solicitation.SetEventStatus("Day2_UnpackingStart", FlagManager.EventStatus.Completed);
            // �C�x���g�̏�Ԃ��擾���ĕ\��
            Debug.Log("2����_�ו��̊J���I��" + solicitation.GetEventStatus("Day2_UnpackingStart"));

            // Flag�A�g
            isDay2 = true;
        }
        solicitation.SetEventStatus("Day2_Visitor2", FlagManager.EventStatus.Completed);
        solicitation.SetEventStatus("Day2_ReadBook", FlagManager.EventStatus.Completed);
    }

    private void Day3Complete()
    {
        // 3���ڂ̃C�x���g�̐i�s��ݒ�
        solicitation.SetEventStatus("Day3_Visitor1", FlagManager.EventStatus.Completed);
        solicitation.SetEventStatus("Day3_Visitor2", FlagManager.EventStatus.Completed);

        if (10 <= SceneFlagManager.Instance.isCardBoardOpened.Count)
        {
            solicitation.SetEventStatus("Day3_UnpackingEnd", FlagManager.EventStatus.Completed);
            // �C�x���g�̏�Ԃ��擾���ĕ\��
            Debug.Log("3����_�ו��̊J���I��" + solicitation.GetEventStatus("Day3_UnpackingEnd"));

            // Flag�A�g
            isDay3 = true;
        }
        solicitation.SetEventStatus("Day3_Visitor3", FlagManager.EventStatus.Completed);
        solicitation.SetEventStatus("Day3_Visitor4", FlagManager.EventStatus.Completed);
        solicitation.SetEventStatus("Day3_FriendLeaves", FlagManager.EventStatus.Completed);
        solicitation.SetEventStatus("Day3_AirConditionerBroken", FlagManager.EventStatus.Completed);
    }

    private void Day4Complete()
    {
        // 4���ڂ̃C�x���g�̐i�s��ݒ�
        solicitation.SetEventStatus("Day4_Visitor1", FlagManager.EventStatus.Completed);
        solicitation.SetEventStatus("Day4_Visitor2", FlagManager.EventStatus.Completed);

        if (isOpenEntrance)
        {
            // BadEnd
            if (isBadEnd)
                return;

            solicitation.SetEventStatus("Day4_Visitor3", FlagManager.EventStatus.Completed);

            solicitation.SetEventStatus("Day4_ChoiceFailure", FlagManager.EventStatus.Completed);
            SceneFlagManager.Instance.isBadEnd = isBadEnd;

            isBadEnd = true;

            // Flag�A�g
            isDay4 = true;
        }
        else if (!isOpenEntrance)
        {
            // NomalEnd
            if (isNomalEnd)
                return;

            solicitation.SetEventStatus("Day4_Visitor3", FlagManager.EventStatus.NotStarted);

            solicitation.SetEventStatus("Day4_ChoiceSuccess", FlagManager.EventStatus.Completed);
            SceneFlagManager.Instance.isNormalEnd = isNomalEnd;

            isNomalEnd = true;

            // Flag�A�g
            isDay4 = true;
        }
    }

    private void NormalEnd()
    {
        solicitation.SetEventStatus("Day4_Visitor3", FlagManager.EventStatus.NotStarted);
    }

    private void BadEnd()
    {
        solicitation.SetEventStatus("Day4_Visitor3", FlagManager.EventStatus.Completed);
    }

    private void ClearCardBoardOpenedFlag()
    {
        SceneFlagManager.Instance.isCardBoardOpened.Clear();
    }
}