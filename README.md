# Pin-array App: Design and Development

> Pin-array App: An artistic application that renders 3D objects and provides UI dashboard for controlling hardware.
>
> <details><summary>SAFETY NOTE (not related to this document)</summary>
> SAFETY NOTE: there are two main instruments, Podium and Pin-Array
> - Pin-Array with several radiator fans
>   - Power Supply (Hongkong socket plug to Chinese plug)
>     - input:  110V/220V (450W)
>   - To avoid burns, avoid touching motors below the Pin-Array
>   - To avoid physical injuries, avoid closing radiator pans behind the Pin-Array
>   - To avoid electric shocks, avoid touching exposed lines and plugs
> - Podium with tablet
>   - Power Supply (Hongkong socket plug to Chinese plug)
>     - input: 220V (==TODO==)
> - Both instruments
>   - To avoid fires, make sure the instruments away from water, dust, direct solar radiation, bad ventilation and elevated environment
>   - To avoid damages to the instruments, make sure the plugs detached from socket before moving them, chemicals away from them, and no heavy objects upon them
> </details>

Prototype: ==***TODO***==

* Administration Scene: Initialization [Only for developers]
  * Choose COM number
  * $m \times n$ size pin-array — [ $(5 \times 5) \cdot (4 \times 4)$ ]
  * `button` — Submit
* **Player Scene**: User participation & Render
  * Right part
    * `button` — Submit [send to hardware], Reset [reset all to 0]
    * `scroll bar` — Handle button with a bar showing range $[0, 150]$ with different colors
    * `panel` — 400-pins array which can be selected individually (also can use dragging for smooth selection), and render with different colors
    * `mini map` — Overview of 400-pins and highlighting for current display (always in square), can be also used for location change
    * Along with function of location change (by dragging)
    * Along with function of **zooming** in (放大) and out (缩小) (by two fingers)
  * Left part: Two types of display — **1.** Left half-screen display; **2.** Full-screen display
    * `wall` — 400-cubes display
    * `button` — Full screen [Left-top, click for full screen or exit full screen]
    * Along with function of location change (by dragging)
    * Along with function of **zooming** in and out (by two fingers)
