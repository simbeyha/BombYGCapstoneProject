using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideUI : MonoBehaviour
{
    [SerializeField]
    private GameObject quest;

    void Update()
    {
        ToggleUI();
    }

    // UI â�� ǥ���ϰų� ����� �޼���
    void ToggleUI()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (quest.transform.GetChild(0).gameObject.activeSelf)
            {
                quest.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                quest.transform.GetChild(0).gameObject.SetActive(true);
            }

        }
    }
}
