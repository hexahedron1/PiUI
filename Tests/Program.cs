using System.Reflection;
using System.Reflection.Metadata;
using PiUI;
using SDL3;

PiUi.DebugDraw = false;
PiUi.Init("Test", 240, 136);
Console.WriteLine(PiUi.Icons);
Window? pWin = PiUi.PrimaryWindow;
if (pWin is null) return;
StackBox box = new(pWin.Renderer, align: Alignment.Start);
pWin.PrimaryContainer = box;
ButtonBox btnBox = new(pWin.Renderer);
Button playBtn = new(pWin.Renderer, icon: Icon.SymbolicPlay);
btnBox.Buttons.Add(playBtn);
Button pauseBtn = new(pWin.Renderer, icon: Icon.SymbolicPause);
btnBox.Buttons.Add(pauseBtn);
Button stopBtn = new(pWin.Renderer, icon: Icon.SymbolicStop);
btnBox.Buttons.Add(stopBtn);
btnBox.Buttons.Add(new Button(pWin.Renderer, "Greg", Icon.Edit));
box.Components.Add(btnBox);
StackBox box2 = new(pWin.Renderer, Direction.Horizontal);
box.Components.Add(box2);
box2.Components.Add(new IconLabel(pWin.Renderer, Icon.Right));
box2.Components.Add(new Label(pWin.Renderer, "Status: ", PiUi.RegularFont));
Led led = new(pWin.Renderer, LedColor.Red);
box2.Components.Add(led);
led.Lit = true;
playBtn.Pressed += () => {
    led.Color = LedColor.Green;
};
pauseBtn.Pressed += () => {
    led.Color = LedColor.Yellow;
};
stopBtn.Pressed += () => {
    led.Color = LedColor.Red;
};

box.Components.Add(new Button(pWin.Renderer, "Save", Icon.Save));
box.Components.Add(new Button(pWin.Renderer, "Save but symbolic", Icon.SymbolicSave));
PiUi.Start();
