using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControllerButtonPrevious : MonoBehaviour
{
    [SerializeField]
    private CamController _camController;

    private void OnMouseDown()
    {
        _camController.PreviousRoom();
    }
}
