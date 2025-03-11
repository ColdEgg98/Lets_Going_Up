using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerCube : MonoBehaviour
{
    private int damage;
    private float waitTime;

    private void Awake()
    {
        damage = 10;
        waitTime = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            InvokeRepeating("MinusHp", 0.5f, waitTime);
    }

    private void OnTriggerExit(Collider other)
    {
        CancelInvoke("MinusHp");
    }

    private void MinusHp()
    {
        ResourceManager.Instance.TakeDamage(damage);
        // HP UI 이벤트 트리거
        DisplayHP.OnHpChanged?.Invoke(ResourceManager.Instance.curHp);
    }
}
