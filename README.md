# PinArray App

> PinArray App: An artistic application that renders 3D objects and provides UI dashboard for controlling hardware.
>
> <details><summary>SAFETY NOTE (not related to this document)</summary>
> SAFETY NOTE: there are two main instruments, Podium and Pin-Array
> - Pin-Array with several radiator fans
>   - Power Supply (Hong Kong socket plug to Chinese plug)
>     - input:  110V/220V (450W)
>   - To avoid burns, avoid touching motors below the Pin-Array
>   - To avoid physical injuries, avoid closing radiator pans behind the Pin-Array
>   - To avoid electric shocks, avoid touching exposed lines and plugs
> - Podium with tablet
>   - Power Supply (Hong Kong socket plug to Chinese plug)
>     - input: 220V (==TODO==)
> - Both instruments
>   - To avoid fires, make sure the instruments away from water, dust, direct solar radiation, bad ventilation and elevated environment
>   - To avoid damages to the instruments, make sure the plugs detached from socket before moving them, chemicals away from them, and no heavy objects upon them
> </details>

### Requirements

<details>
<summary>Prototype - Sketch Map</summary>
<img src="https://github.com/huang-feiyu/HK-PinArray-App/assets/70138429/b25da606-d755-46dc-bf3e-52a42740bfde"/>
</details>


* *Administrator Scene*: Initialization [Only for developers]
  * `drop-down menu` — Choose COM number
  * `input field` — $m \times n$ size pin-array — [ $(5 \times 5) \cdot (4 \times 4)$ ]
  * `button` — Submit
* ***Player Scene***: User participation & Render
  * Right part
    * `button` — Select All, Submit [send to hardware], Reset [reset all to 0]
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

### Development Plan

- [x] *Administrator Scene*
  - [x] `drop-down menu` for choosing COM number
  - [x] `input field` for the numbers of rows and columns
  - [x] `button` for submitting and transferring to ***Player Scene***
- [ ]  ***Player Scene*** - Right Part
  - [x] `panel` for displaying and manipulating (for now, use click for selection)
  - [x] `scroll bar` for changing heights; at the same time, `panel` also changes heights
  - [x] `button` for selecting/unselecting all, generating JSON strings, sending to hardware, returning to admin (Debug)
  - [ ] Different colors display which depends on height
  - [ ] Zooming and Dragging for better user experience
  - [ ] Better appearance
- [ ]  ***Player Scene*** - Left Part
  - [x] `wall` for rendering onscreen (only half-screen type for now)
  - [ ] `button` for entering and exiting full-screen
  - [ ] Zooming and Dragging for better user experience
  - [ ] Better appearance

### Current

* Administrator Scene

![Admin](https://github.com/huang-feiyu/HK-PinArray-App/assets/70138429/6c545910-98c9-42ca-9cbb-023e33bc5e44)

* Right Part (Manipulation)

![Right Part](https://github.com/huang-feiyu/HK-PinArray-App/assets/70138429/a9ba5d16-9705-4dc5-aa7e-90a71ee61e6a)

* Left Part (Rendering)

![Left Part](https://github.com/huang-feiyu/HK-PinArray-App/assets/70138429/557e86de-e4e2-4aa0-8e35-a0396f16072d)
