using System;
using UnityEngine;

public class MaterialManager : MonoBehaviour {
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material hoverMaterial;
    [SerializeField] Material cooldownMaterial;
    
    public void ChangeLeavesMaterial(MeshRenderer meshRenderer, LeavesMaterial leavesMaterial) {
            switch (leavesMaterial) {
                case LeavesMaterial.Default:
                    meshRenderer.material = defaultMaterial;
                    break;
                case LeavesMaterial.Hovered:
                    meshRenderer.material = hoverMaterial;
                    break;
                case LeavesMaterial.Cooldown:
                    meshRenderer.material = cooldownMaterial;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    
    public enum LeavesMaterial {
        Default,
        Hovered,
        Cooldown
    }
}