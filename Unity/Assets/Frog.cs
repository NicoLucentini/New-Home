using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Character {


    public void Update()
    {
        if (input == null) return;


        transform.Rotate(new Vector3(0, input.inputHorizontal * 90 * Time.deltaTime, 0));

        if (isCharging)
        {
            chargeValue += Time.deltaTime;
            chargeValue = Mathf.Clamp(chargeValue, 0, 2);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCharging = true;
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isCharging = false;
            if (jump != null)
                StopCoroutine(jump);
            jump = StartCoroutine(Jump(chargeValue * 10, .5f));
            chargeValue = 0;
        }



    }
    Coroutine jump;
    float chargeValue = 0;
bool isCharging;

    IEnumerator Jump(float maxForwardForce, float duration)
    {

        //esto va a du

        float timer = 0;
        Vector3 init = transform.position;
        Vector3 end = transform.position + transform.forward * maxForwardForce;

        float y = transform.position.y;

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        float initY = y;
        float maxY = initY +  maxForwardForce / 2;
        float totalY = y + 1 * maxForwardForce;
        float grav = 0;
        Vector3 resultantLerp = Vector3.zero;

        float halfDuration = duration / 2;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            resultantLerp = Vector3.Slerp(init, end, timer / duration);

            if (timer < halfDuration)
                y = Mathf.Lerp(initY, maxY, timer / halfDuration);
            else
                y = Mathf.Lerp(maxY, initY, (timer - halfDuration) / halfDuration);

            transform.position = new Vector3(resultantLerp.x, y, resultantLerp.z);

            yield return null;
        }

        bool res = Physics.Raycast(transform.position, Vector3.down, .25f);
        while (!res) {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
        }
        
        //    transform.position = new Vector3(transform.position.x, initY, transform.position.z);

        


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + Vector3.up , transform.position + Vector3.up  + transform.forward * chargeValue * 10);
    }
}
