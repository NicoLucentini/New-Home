using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType {
    BIRD,
    FROG,
    FOX,
    FISH,
    CARACOL,

}

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Character current;
    public List<House> animalsHomes;

    public Transform cameraGo;

    public List<CharacterType> alreadyPlayed;
    public List<Character> characters;
    public int index;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        House.onCharacterArrivedHome += OnCharacterArrivedHome;

        index = Random.Range(0, characters.Count);

        SetCharacter(characters[index]);
    }

    void OnCharacterArrivedHome() {
        //Hacer algo...
        index++;
        if (index > characters.Count - 1)
            index = 0;
        SetCharacter(characters[index]);
        print("Alguien llego a su casa");
    }
    public void SetCharacter(Character character)
    {
        this.current = character;
        current.input = GetComponent<CharacterInput>();

        cameraGo.SetParent(current.transform, false);
        cameraGo.position = current.transform.position - current.transform.forward * 7 + new Vector3(0, 3f, 0);
        cameraGo.LookAt(current.transform.position + current.transform.forward * 10);
        //cameraGo.position = Vector3.zero;
        //cameraGo.eulerAngles = Vector3.zero;

        //cameraGo.localPosition = current.transform.position - new Vector3(0, -3, 10);
        // cameraGo.LookAt(current.transform.position + current.transform.forward * 10);
    }
}

public class LocationSpots {
    

}