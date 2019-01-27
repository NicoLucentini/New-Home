using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Character {

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        type = CharacterType.FOX;
	}
	
	// Update is called once per frame
	void Update () {
        if (input != null)
            Movement();	
	}

    float speed = 3;
    float rotation = 90;
    public void Movement() {
        transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float y = Input.GetAxis("Horizontal") * rotation * Time.deltaTime;
        transform.Rotate(new Vector3(0, y, 0));
    }
}
