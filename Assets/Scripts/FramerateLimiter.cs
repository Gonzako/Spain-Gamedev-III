using UnityEngine;

public class FramerateLimiter : MonoBehaviour
{

    void Awake() 
    {
        Application.targetFrameRate = 60; // La GPU lo agradecera
    }

}
