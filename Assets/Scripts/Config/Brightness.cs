using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Brightness : MonoBehaviour
{
    public Light mainLight; // Main Light�̎Q��
    public Slider brightnessSlider; // Slider�̎Q��
    public VolumeProfile volumeProfile;
    public GlobalVolume globalVolume; // Global Volume�̎Q��
    
    private SplitToning splitToning; // Bloom�G�t�F�N�g�̎Q��

    void Start()
    {
        // Global Volume����SplitToning�G�t�F�N�g���擾
        globalVolume.volumeProfile.TryGet(out splitToning);
        // Slider�̏����l��ݒ�
        brightnessSlider.value = mainLight.intensity;
        // Slider�̒l���ύX���ꂽ�Ƃ��̃C�x���g��o�^
        brightnessSlider.onValueChanged.AddListener(ChangeBrightness);
    }

    // ���邳��ύX����֐�
    void ChangeBrightness(float newValue)
    {
        mainLight.intensity = newValue;

        // Bloom�G�t�F�N�g��Intensity�p�����[�^�𒲐�����
        splitToning.balance.Override(newValue * 5); // 5�͓K�؂Ȕ{���ł����K�v�ɉ����Ē������Ă�������
    }
}