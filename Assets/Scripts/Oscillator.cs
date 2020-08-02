using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f,10f,10f);
    [SerializeField] float period = 2f;
    [Range(0, 1)] [SerializeField] float movementFactor;

    // Start is called before the first frame update
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Mathf.Epsilon
        float cycles = Time.time / (period + 0.0001f);
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave + 1) / 2;
        transform.position = startPos + (movementVector * movementFactor);
    }
}
