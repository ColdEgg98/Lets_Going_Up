using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class JumpPlane : MonoBehaviour
{
    [SerializeField] private float jumpForce = 200f;

    private bool isEnter; // �� �� ���� ����
    private bool isInvoke;
    private void Awake()
    {
        isEnter = false;
        isInvoke = false;
    }

    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.CompareTag("Player") && isEnter == false)
        {
            CharacterController chacon = Player.GetComponentInParent<CharacterController>();
            isEnter = true;
            StartCoroutine(JumpDirect(chacon));
        }
    }

    // �ִϸ��̼��� �� �� �׷���
    private IEnumerator JumpDirect(CharacterController Player)
    {
        Debug.Log("JumpDirect ����");

        float time;
        Vector3 preVelocity = transform.position;
        Vector3 velocity = preVelocity;
        
        time = 0;
        while (time < 1) // ����
        {
            time += Time.fixedDeltaTime;
            velocity.y -= time * 0.09f;
            transform.position = velocity;
            yield return null;
        }
        
        time = 0;
        while (time < 0.7f) // �ݵ�
        {
            time += Time.fixedDeltaTime;
            velocity.y += time * 0.5f;

            // �÷��̾ ���� �� ����
            if (velocity.y >= preVelocity.y && isInvoke == false)
            {
                JumpUP(Player);
                isInvoke = true;
            }

            transform.position = velocity;
            yield return null;
        }

        
        time = 0;
        while (velocity.y >= preVelocity.y) // ���ڸ��� ���ƿ�
        {
            time += Time.fixedDeltaTime;
            velocity.y -= time * .1f;
            transform.position = velocity;
            yield return null;
        }
        transform.position = preVelocity;
    }

    private void JumpUP(CharacterController Player)
    {
        Debug.Log("JumpUP ����");

        Vector3 velocity = Player.velocity;

        velocity.y = jumpForce;
        Player.Move(velocity * Time.deltaTime);
        isEnter = false;
        isInvoke = false;
    }

    private void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.CompareTag("Player") && isEnter == true)
        {
            CharacterController chacon = Player.GetComponentInParent<CharacterController>();
            Invoke("Exit", .5f);
        }
    }

    public void Exit()
    {
        // 2�� ���� ����
        isEnter = false;
        isInvoke = false;
    }
}
