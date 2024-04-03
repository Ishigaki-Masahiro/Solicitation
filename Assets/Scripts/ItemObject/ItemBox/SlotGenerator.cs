using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGenerator : MonoBehaviour
{
    // �ǂ��ł����s�ł�����
    public static SlotGenerator instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] GameObject slot;

    public void Spawn()
    {
        Instantiate(slot, this.transform);
    }
}
