using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void PlayGame() {

        int selectedCharacter = int.Parse(
            UnityEngine.EventSystems.EventSystem.
                current.currentSelectedGameObject.name
        );
    
        GameController.Instance.CharIndex = selectedCharacter;
        SceneManager.LoadScene(Tags.GAME_PLAY_SCENE);
    }
}
