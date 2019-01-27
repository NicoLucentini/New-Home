using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Character {

   

    public Rigidbody rb;
    public float wingForce;
    public float verticalRotation;
    public float horizontalRotation;
    public float qeRotation;

    public override void Start () {
        base.Start();

        rb  = GetComponent<Rigidbody>();
    
        type = CharacterType.BIRD;
	}
	
	void Update () {
        if(input != null)
          Fly();
	}

    public float speed = 0;
    public float minSpeed = 3f;
    Vector3 grav;
    public AnimationCurve speedCurve;
    public void Fly() {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            grav = Vector3.zero;
            if (wing != null)
                StopCoroutine(wing);

           wing = StartCoroutine(WingCt());
           
        }
   

        if (speed == minSpeed)
            grav += Vector3.up * 9.81f * Time.deltaTime;
        else
            rb.velocity = transform.forward * speed - grav;

        GetComponent<Animator>().speed = 0.5f + speed / 100;

       float x = input.inputVertical * -verticalRotation * Time.deltaTime;
        float y = input.inputHorizontal * horizontalRotation * Time.deltaTime;
        float z = input.inputQE * -qeRotation * Time.deltaTime;
        transform.Rotate(new Vector3(x, 0, z));

        transform.localEulerAngles += new Vector3(0, y, 0);
    }

    Coroutine wing;
    float accel = 2;
    IEnumerator WingCt() {

        float timeElapsed = 0;
        speed = speedCurve.Evaluate(timeElapsed) * wingForce;
        while (speed > minSpeed) {

            //  speed = speedCurve.Evaluate(timeElapsed) * wingForce;
                speed -= accel * Time.deltaTime;
                timeElapsed += Time.deltaTime;
                yield return null;
          
        }

        speed = minSpeed;
    }

}
