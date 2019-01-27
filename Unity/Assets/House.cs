using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    public CharacterType type;

    public static System.Action onCharacterArrivedHome;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9) {
            if (other.gameObject.GetComponent<Character>().type == type) {

                onCharacterArrivedHome();

            }

        }
    }
}
