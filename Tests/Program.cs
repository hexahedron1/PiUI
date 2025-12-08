using PiUI;

PiUi.DebugDraw = true;
PiUi.Init("Test", 240, 136);

Window? pWin = PiUi.PrimaryWindow;
if (pWin != null) {
    StackBox box = new(pWin.Renderer);
    pWin.PrimaryContainer = box;
}

PiUi.Start();