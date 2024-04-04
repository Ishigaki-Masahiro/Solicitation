using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerAction : MonoBehaviour
{
    public float interactionDistance = 2f; // ���C�̍ő勗��
    public KeyCode interactKey = KeyCode.E; // �C���^���N�g�Ɏg���L�[
    public List<Slider> interactionSlider=new List<Slider>(); // �C���^���N�g�Q�[�W��\������Slider
    public List<GameObject> sliderPanel=new List<GameObject>(); // SliderPanel��\�����邽�߂̃p�l��
    public GameObject cardboardOpen;
    public float currentValue;

    private bool isInteracting = false; // �C���^���N�g�����ǂ���
    private float interactionProgress = 0f; // �C���^���N�g�̐i���x
    private int i = 0;

    PlayerLife playerLife;

    private void Start()
    {
        playerLife = GetComponent<PlayerLife>();

        // ������Ԃł̓Q�[�W�p�l�����\���ɂ���
        foreach (var panel in sliderPanel)
        {
            panel.SetActive(false);
        }
    }

    void Update()
    {
        if (!SceneFlagManager.Instance.isPlayerMoving || playerLife.isGameOver)
            return;

        // ���C���΂��ăC���^���N�g�\�ȃI�u�W�F�N�g�����o
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Card"))
            {
                Outline outline = hit.collider.GetComponent<Outline>();
                outline.enabled = true;

                // E�L�[��������A���C���^���N�g���łȂ��ꍇ
                if (Input.GetKeyDown(interactKey) && !isInteracting)
                {
                    // �p�l���\��
                    sliderPanel[i].SetActive(true);

                    isInteracting = true;
                }

                // E�L�[�������Ă���Ԃ�Slider�𑝂₷
                if (isInteracting)
                {
                    interactionProgress += Time.deltaTime * currentValue;
                    interactionSlider[i].value = interactionProgress;

                    if(100 <= interactionProgress)
                    {

                        ItemText.OnItemText.Invoke();

                        sliderPanel[i].SetActive(false);

                        // �C���f�b�N�X�����̃Q�[�W�ɐi�߂�
                        i++;

                        // �C���f�b�N�X���Q�[�W���ȏ�̏ꍇ�̓��Z�b�g
                        if (interactionSlider.Count <= i)
                        {
                            i = 0;
                        }

                        // �v���n�u�𐶐�
                        Instantiate(cardboardOpen, hit.collider.transform.position, Quaternion.identity);
                        
                        // �A�C�e���������Ȃǂ̏��������s
                        Destroy(hit.collider.gameObject);

                        // �Q�[�W�����Z�b�g
                        interactionProgress = 0;

                        // �C���^���N�g���I��
                        isInteracting = false;
                    }
                }

                // E�L�[�������ꂽ��SliderPanel���\���ɂ���
                if (Input.GetKeyUp(interactKey))
                {
                    isInteracting = false;
                }
            }
            else if(hit.collider.CompareTag("Item"))
            {
                Outline outline = hit.collider.GetComponent<Outline>();
                outline.enabled = true;

                PickupObj pickupObj = hit.collider.GetComponent<PickupObj>();
                pickupObj.OnPointerClick();
            }
            else
            {
                // E�L�[�𗣂��Ă��Q�[�W�����Z�b�g���Ȃ�
                if (!Input.GetKey(interactKey))
                {
                    isInteracting = false;
                }
            }
        }
        else
        {
            // E�L�[�𗣂��Ă��Q�[�W�����Z�b�g���Ȃ�
            if (!Input.GetKey(interactKey))
            {
                isInteracting = false;
                sliderPanel[i].SetActive(false);
            }
        }
    }
}