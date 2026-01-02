using System.Reflection;
using PiUI;
using SDL3;

PiUi.DebugDraw = false;
PiUi.Init("Test", 240, 136);
Window? pWin = PiUi.PrimaryWindow;
if (pWin is null) return;
StackBox box = new(pWin.Renderer);
pWin.PrimaryContainer = box;
ButtonBox btnBox = new(pWin.Renderer);
Button btn1 = new(pWin.Renderer, "Button1");
btnBox.Buttons.Add(btn1);
Button btn2 = new(pWin.Renderer, "Button2");
btnBox.Buttons.Add(btn2);
Button btn3 = new(pWin.Renderer, "Button3");
btnBox.Buttons.Add(btn3);
box.Components.Add(btnBox);
PiUi.Start();
