using System.Reflection;
using PiUI;
using SDL3;

PiUi.DebugDraw = false;
PiUi.Init("Test", 240, 136);
Window? pWin = PiUi.PrimaryWindow;
if (pWin is null) return;
StackBox box = new(pWin.Renderer);
pWin.PrimaryContainer = box;
Button btn = new(pWin.Renderer, "Toggle");
box.Components.Add(btn);
Led led = new Led(pWin.Renderer, LedColor.Green);
box.Components.Add(led);
btn.Pressed += () => {
    led.Lit = !led.Lit;
    btn.Text = led.Lit ? "On" : "Off";
};
PiUi.Start();
