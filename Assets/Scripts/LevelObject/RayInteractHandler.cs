using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteractHandler : MonoBehaviour
{
    public RayInteractObject RayInstance;

    public string GetNameNDescrip()
    {
        return $"{RayInstance.objName}\n{RayInstance.objDescription}";
    }

    public void UseItem()
    {
        float curHp = ResourceManager.Instance.curHp;
        int maxHp = ResourceManager.Instance.maxHp;

        if(RayInstance.useAble == true)
        {
            switch(RayInstance.useAbleTable.ToString())
            {
                case ("Health"):
                    ResourceManager.Instance.curHp =
                        Mathf.Min((int)((maxHp * (RayInstance.value * 0.01f)) + curHp), maxHp);
                    DisplayHP.OnHpChanged?.Invoke(ResourceManager.Instance.curHp);
                    Destroy(gameObject);
                    break;
                case ("Speed"):
                    StartCoroutine(SpeedBoost());
                    if (gameObject.TryGetComponent<Renderer>(out Renderer Render))
                        Render.enabled = false;
                    break;
                case ("wall"):
                    Destroy(gameObject);
                    break;
                default:
                    Debug.LogWarning("다른 값이 들어왔습니다.");
                    break;
            }
        }
    }

    public IEnumerator SpeedBoost()
    {
        Debug.Log("Start SpeedBoost");

        float boostAmount = RayInstance.value;
        ThirdPersonController.SprintSpeed += boostAmount;
        ThirdPersonController.MoveSpeed += boostAmount;
        yield return new WaitForSeconds(5);
        ThirdPersonController.SprintSpeed -= boostAmount;
        ThirdPersonController.MoveSpeed -= boostAmount;
        Debug.Log("End SpeedBoost");
        Destroy(gameObject);
    }
}
