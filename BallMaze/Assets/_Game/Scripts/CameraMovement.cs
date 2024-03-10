using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float velocidadeDaCamera;
    void Update()
    {
        transform.Translate(Vector3.right * (velocidadeDaCamera * Time.deltaTime));
    }
}
