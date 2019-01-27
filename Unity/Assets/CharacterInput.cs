using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour {

    public float inputHorizontal;
    public float inputVertical;
    public float inputSpace;
    public float inputQE;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        inputQE = Input.GetAxis("QE");
        inputSpace = Input.GetAxis("Jump");
    }
}
