using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float zoomSmooth = 1f;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float orthographicSize;
    private float targetOrthographicSize;
    [SerializeField] private Vector2 orthographicRage;

    private void Start() {
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        CameraZoom();
    }

    void CameraMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");        
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(horizontal, vertical).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    void CameraZoom()
    {
        targetOrthographicSize += Input.mouseScrollDelta.y * zoomSpeed;
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, orthographicRage.x, orthographicRage.y);

        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime * zoomSmooth);
        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }
}
