using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    // replace the `cam` variable with your camera.
    public Camera _camMinimap;
    //These are the positions and dimensions of the Camera view in the Game view
    float m_ViewPositionX, m_ViewPositionY, m_ViewWidth, m_ViewHeight;

    //[SerializeField] Camera cam;
    //float w = < 1920 >;
    //float h = < 1080 >;
    //float x = w * 0.5f - 0.5f;
    //float y = h * 0.5f - 0.5f;
    void Start()
    {
        //This sets the Camera view rectangle to be in the bottom corner of the screen
        //m_ViewPositionX = 0;
        //m_ViewPositionY = 0;

        //This sets the Camera view rectangle to be smaller so you can compare the orthographic view of this Camera with the perspective view of the Main Camera
        m_ViewWidth = 1920f;
        m_ViewHeight = 1080f;

        //This enables the Camera (the one that is orthographic)
        _camMinimap.enabled = true;

        //If the Camera exists in the inspector, enable orthographic mode and change the size
        if (_camMinimap)
        {
            //This enables the orthographic mode
            _camMinimap.orthographic = true;
            //Set the size of the viewing volume you'd like the orthographic Camera to pick up (5)
            //_camMinimap.orthographicSize = 5.0f;
            //Set the orthographic Camera Viewport size and position
            _camMinimap.rect = new Rect(m_ViewPositionX, m_ViewPositionY, m_ViewWidth, m_ViewHeight);
        }
    }
}
