# <p align="center">Mandelbrot Explorer</p>

<img align="right" width="300" height="300" src="https://github.com/JackGannonUK/Mandelbrot-UnityApp/blob/main/assets/mlogo.png">

### About
Mandelbrot-UnityApp is an application built in Unity which utilises basic shadertoy scripts. Mandelbrot-UnityApp features a camera controller, allowing you to glide within the Mandelbrot Set.

### Controls
Below are the controls for navigating through the program:

 - W, A, S, D: Up, Down, Left, Right
 - I: Zoom In
 - O: Zoon Out
 - L: Rotate Left
 - R: Rotate Right

Through the use of the `Lerp` function in Unity, we have a nice, smooth, navigation experience of the fractal. This is accomplished with the use of:

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

### Known Issues

Zooming is limited, after a certain range the fractal will begin to pixelate and you won't be able to zoom in further.

## Screenshots

<img align="center" src="https://github.com/JackGannonUK/Mandelbrot-UnityApp/blob/main/assets/topview.png">
<img align="center" src="https://github.com/JackGannonUK/Mandelbrot-UnityApp/blob/main/assets/repeats.png">
<img align="center" src="https://github.com/JackGannonUK/Mandelbrot-UnityApp/blob/main/assets/outside.png">
<img align="center" src="https://github.com/JackGannonUK/Mandelbrot-UnityApp/blob/main/assets/branch.png">

