using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextProperty : MonoBehaviour
{
    public TMP_Text ToolTipText { get { return gameObject.GetComponent<TMP_Text>(); } //TMP_Text �޾ƿͼ� ��ȯ
        set 
        {
            ToolTipText = value;
        } }
}