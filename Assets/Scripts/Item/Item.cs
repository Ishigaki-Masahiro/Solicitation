using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string ID;

    void Start()
    {
        //������ �擾��Ԃ̊m�F
        if (ItemLogger.Contains(ID))
        {
            Debug.Log("�A�C�e�����l���ς�");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("�i�{�[�����J���ĂȂ���");
        }
    }

    public void GetCardBoard()
    {
        Debug.Log($"ID + {ID}");
        ItemLogger.Add(ID);
        Destroy(gameObject);
    }
}