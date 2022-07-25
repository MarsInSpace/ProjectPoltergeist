using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitDetection : MonoBehaviour
{
    Material Material;
    Color MaterialStartColor;

    [HideInInspector]
    public GameObject GameManager;
    GameManager ManagerScript;

    void Start() {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        ManagerScript = GameManager.GetComponent<GameManager>();
        Material = GetComponent<Renderer>().material;
        MaterialStartColor = Material.color;
    }

    void OnMouseOverColor() {
        Material.color = Color.red;
        Material.EnableKeyword("_EMISSION");
        Material.SetColor("_EmissionColor", Color.red);
        ManagerScript.IsOverPossessable = true;
    }

    private void OnMouseOver() {
        OnMouseOverColor();
    }

    private void OnMouseExit() {
        Material.color = MaterialStartColor;
        Material.DisableKeyword("_EMISSION");
        ManagerScript.IsOverPossessable = false;
    }
}
