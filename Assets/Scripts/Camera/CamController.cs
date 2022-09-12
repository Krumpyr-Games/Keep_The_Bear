using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _roomOrigin;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private float lerpDuration = 3;


    private bool _interpolation = false;
    private int _currentRoomIndex = 0;
    private Vector3 _previousOrigin;
    
    

    void Start()
    {
        IndexCheck();
        _previousOrigin = _roomOrigin[0].position;
    }
        

    public void NextRoom()
    {


        if (_interpolation) return;

        _interpolation = true;

        _currentRoomIndex++;

        IndexCheck();

        StartCoroutine(ChangeRoom());

    }

   public void PreviousRoom()
    {


        if (_interpolation) return;

        _interpolation = true;

        _currentRoomIndex--;

        IndexCheck();

        StartCoroutine(ChangeRoom());


    }


    private void IndexCheck()
    {
        if (_currentRoomIndex < 0)
        {
            _currentRoomIndex = _roomOrigin.Count - 1;
        }

        if (_currentRoomIndex > _roomOrigin.Count)
        {
            _currentRoomIndex = 0;
        }
    }




    IEnumerator ChangeRoom()
    {


        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            

            transform.position = Vector3.Lerp(_previousOrigin,_roomOrigin[_currentRoomIndex].position , timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        _previousOrigin = _roomOrigin[_currentRoomIndex].position; 

        _interpolation = false;
    }

}
