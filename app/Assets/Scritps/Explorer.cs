using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorer : MonoBehaviour
{
    public Material mat;
    public Vector2 pos;
    public float scale, angle;

    private Vector2 smoothPos;
    private float smoothScale, smoothAngle;

    private void UpdateShader()
    {
        smoothPos = Vector2.Lerp(smoothPos, pos, .03f); // Movement
        smoothScale = Mathf.Lerp(smoothScale, scale, .03f); // Zooming in + out
        smoothAngle = Mathf.Lerp(smoothAngle, angle, .03f); // Rotating
        
        float aspect = (float)Screen.width / (float)Screen.height;
        
        float scaleX = smoothScale;
        float scaleY = smoothScale;

        if(aspect > 1f)
            scaleY /= aspect;
        else
            scaleX *= aspect;

        mat.SetVector("_Area", new Vector4(smoothPos.x, smoothPos.y, scaleX, scaleY));
        mat.SetFloat("_Angle", smoothAngle);
    }

    private void HandleInputs()
    {
        // Zoom in
        if(Input.GetKey(KeyCode.I))
            scale *= .99f;
        // Zoom out
        if(Input.GetKey(KeyCode.O))
            scale *= 1.01f;

        // Rotate Right
        if(Input.GetKey(KeyCode.R))
            angle -= .01f;
        // Rotate Left
        if(Input.GetKey(KeyCode.L))
            angle += .01f;

        // Movement (W, A, S, D)
        Vector2 dir = new Vector2(.01f * scale, 0);
        float s = Mathf.Sin(angle);
        float c = Mathf.Cos(angle);
        dir = new Vector2(dir.x*c, dir.x*s);

        if(Input.GetKey(KeyCode.A)) // Left
            pos -= dir;
        if(Input.GetKey(KeyCode.D)) // Right
            pos += dir;

        dir = new Vector2(-dir.y, dir.x); // Keep Rotations consistent 

        if(Input.GetKey(KeyCode.S)) // Down
            pos -= dir;
        if(Input.GetKey(KeyCode.W)) // Up
            pos += dir;
    }

    void FixedUpdate()
    {
        HandleInputs();
        UpdateShader();
    }
}
