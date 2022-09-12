using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControllerButtonNext : MonoBehaviour
{
    [SerializeField]
    private CamController _camController;

    private void OnMouseDown()
    {

        _camController.NextRoom();
    }
}
