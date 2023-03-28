
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(this); //The music player plays the same clip for all scenes, so it is not deleted. 
    }


}
