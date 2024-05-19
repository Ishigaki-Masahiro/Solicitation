using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerAction : MonoBehaviour
{
    public float interactionDistance = 3f; // ���C�̍ő勗��
    public KeyCode interactKey = KeyCode.E; // �C���^���N�g�Ɏg���L�[
    public List<Slider> interactionSlider=new List<Slider>(); // �C���^���N�g�Q�[�W��\������Slider
    public List<GameObject> sliderPanel=new List<GameObject>(); // SliderPanel��\�����邽�߂̃p�l��
    public GameObject cardboardOpen;
    public float currentValue;

    private bool isInteracting = false; // �C���^���N�g�����ǂ���
    private float interactionProgress = 0f; // �C���^���N�g�̐i���x
    private int i = 0;

    PlayerLife playerLife;
    Outline outline;
    Item item;

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
        if (!SceneFlagManager.Instance.isPlayerMoving || 
            SceneFlagManager.Instance.isSetting ||
            playerLife.isGameOver)
            return;

        // ���C���΂��ăC���^���N�g�\�ȃI�u�W�F�N�g�����o
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Card"))
            {
                // Outline�擾
                outline = hit.collider.GetComponent<Outline>();

                // Item�擾
                item = hit.collider.GetComponent<Item>();

                // E�L�[��������A���C���^���N�g���łȂ��ꍇ
                if (Input.GetKeyDown(interactKey) && !isInteracting)
                {
                    // �p�l���\��
                    sliderPanel[i].SetActive(true);

                    isInteracting = true;

                    // �A�E�g���C���\��
                    outline.enabled = true;
                }

                // E�L�[�������Ă���Ԃ�Slider�𑝂₷
                if (isInteracting)
                {
                    interactionProgress += Time.deltaTime * currentValue;
                    interactionSlider[i].value = interactionProgress;

                    // �A�E�g���C���\��
                    outline.enabled = true;

                    if (100 <= interactionProgress)
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

                        // Item�擾
                        item.GetCardBoard();

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

                    // �A�E�g���C����\��
                    outline.enabled = false;
                }
            }
            else if(hit.collider.CompareTag("Door"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("DoorOpen");
                    Animator animator = hit.collider.GetComponentInParent<Animator>();
                    animator.SetBool("openAnim", true);
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("DoorClose");
                    Animator animator = hit.collider.GetComponentInParent<Animator>();
                    animator.SetBool("openAnim", false);
                }
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