using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [Header ("Stat")]
    public int maxHp;
    public int curHp;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        // √ ±‚»≠
        maxHp = 100;
        curHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        curHp = (curHp - damage <= 0) ? 0 : curHp - damage;
        if (curHp == 0)
            PlayerState.IsDead = true;
    }
}