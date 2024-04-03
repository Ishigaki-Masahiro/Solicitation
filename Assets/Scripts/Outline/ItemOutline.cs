using DG.Tweening;
using UnityEngine;

public class ItemOutline : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] private float fadeInTime = 1.0f;
    [SerializeField] private float fadeInAlpha = 1.0f;
    [SerializeField] private float fadeOutTime = 1.0f;
    [SerializeField] private float fadeOutAlpha = 0.0f;
    private Outline[] outline;

    private void Start()
    {
        outline = this.gameObject.GetComponentsInChildren<Outline>(); //Outline���K�p���ꂽ�q���擾
    }

    private void OnTriggerEnter(Collider other) //�t�F�[�h�C��
    {
        if (other.CompareTag("Player"))
        {
            foreach (var outline in outline)
            {
                DOVirtual.Float(0f, fadeInAlpha, fadeInTime, fadeInAlpha =>
                {
                    color.a = fadeInAlpha;
                    outline.OutlineColor = color;
                });
            }
        }
    }

    private void OnTriggerExit(Collider other) //�t�F�[�h�A�E�g
    {
        if (other.CompareTag("Player"))
        {
            foreach (var outline in outline)
            {
                DOVirtual.Float(1f, fadeOutAlpha, fadeOutTime, fadeOutAlpha =>
                {
                    color.a = fadeOutAlpha;
                    outline.OutlineColor = color;
                });
            }
        }
    }
}