using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement
{
    [SerializeField, Header("Config")] private float speed;
    private InputAction actions;
    private readonly string pathActions = "..\\Actions\\Movement";

    private void Awake()
    {
        if (File.Exists(pathActions))
        {
            Debug.Log("Achado!");
            actions = new InputAction(File(pathActions));
        }
        else
        {
            Debug.Log("NÃO Achado...");
        }
    }
}
