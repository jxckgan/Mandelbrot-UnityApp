# <p align="center">Mandelbrot Explorer</p>

<img align="right" width="300" height="300" src="https://github.com/JackGannonUK/Mandelbrot-UnityApp/blob/main/assets/mlogo.png">

## About
Mandelbrot-UnityApp is an application built in Unity - utilizing basic shadertoy scripts. Meaning it is swift, minimal and efficient. The only C# programming used is the camera controller; these scripts feature explanatory comments - making them comprehensible for neophytes / those who want to comprehend the inner mechanisms of the program. Mandelbrot-UnityApp features a slick camera controller, allowing you to glide deep within the Mandelbrot Set - exposing its innate beauty.

## Controls
Mandelbrot-UnityApp features an exhaustive suite of tools that assist the user in navigating the Fractal.

 - W, A, S, D: Up, Down, Left, Right
 - I: Zoom In
 - O: Zoon Out
 - L: Rotate Left
 - R: Rotate Right

Using the `Lerp` function in Unity, we have successfully made a smooth navigation experience of the fractal. E.g.

```cs
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
```
