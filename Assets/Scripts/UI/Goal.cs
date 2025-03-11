using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI goalMessage;
    private void OnTriggerEnter(Collider other)
    {
        goalMessage.gameObject.SetActive(true);
    }
}
