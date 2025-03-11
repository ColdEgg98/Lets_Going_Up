using StarterAssets;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RayCastHit : MonoBehaviour
{
    // Ray
    Ray ray;
    RaycastHit hit;
    private float maxDistance;
    public LayerMask mask;

    // Pivot
    [SerializeField] Transform CameraPivot;

    // Description Text
    [SerializeField] TextMeshProUGUI descripText;
    
    // Interaction
    RayInteractHandler interactHandler;
    public static Action getInputAction;
    private bool isInput;

    private void Start()
    {
        maxDistance = 3f;
        isInput = false;
        getInputAction += DetectInput;
        if (descripText == null)
        {
            Debug.LogWarning("descripText를 찾지 못함!");
            descripText = GetComponentInChildren<TextMeshProUGUI>();
        }
        if (CameraPivot == null)
            CameraPivot = GameObject.FindWithTag("CinemachineTarget").transform;
    }

    void Update()
    {
        ray = new Ray(CameraPivot.position, CameraPivot.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);

        if (Physics.Raycast(ray, out hit, maxDistance, mask))
        {
            if (hit.collider.gameObject.TryGetComponent<RayInteractHandler>(out interactHandler) && isInput && interactHandler.RayInstance.useAble == true)
                interactHandler.UseItem();

            else if (hit.collider.gameObject.TryGetComponent<RayInteractHandler>(out interactHandler))
                descripText.text = interactHandler.GetNameNDescrip();

            else
                descripText.text = "";

        }
        else
            descripText.text = "";
        isInput = false;
    }

    private void DetectInput()
    {
        isInput = true;
    }
}
