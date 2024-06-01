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
    public VolumeProfile profile;
    
    private SplitToning splitToning; // Bloom�G�t�F�N�g�̎Q��
    // private ColorAdjustments colorAdjustments; // ColorAdjustments�̎Q��

    void Start()
    {
        // Global Volume����SplitToning�G�t�F�N�g���擾
        profile.TryGet(out splitToning);
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
        splitToning.balance.Override(newValue * 5); // -30�`30�����x����
        // colorAdjustments.postExposure.Override(newValue * 5); // ����т�����^�����ɂȂ�
    }
}
