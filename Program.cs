using System;
using Gtk;
using Gdk;


class Program
{
    [Obsolete]
    static void Main(string[] args)
    {
        Application.Init();
        var win = new MainWindow();
        SettingsButton settingsBtn = new SettingsButton();
        win.Add(settingsBtn);
        win.ShowAll();

        // Posição da janela no canto inferior direito
        var screen = Display.Default.DefaultScreen;
        int width = 300;
        int height = 100;
        win.Resize(width, height);
        win.Move(screen.Width - width - 10, screen.Height - height - 40);

        // Interface
        VBox box = new VBox();
        Label label = new Label();
        label.Markup = "<span foreground='white' font='12'>🎵 Nenhuma música tocando</span>";

        Button playBtn = new Button("⏯️");
        playBtn.Clicked += (sender, e) =>
        {
            label.Markup = "<span foreground='lightgreen' font='12'>▶️ Tocando música de exemplo</span>";
        };

        box.PackStart(label, true, true, 5);
        box.PackStart(playBtn, false, false, 5);

        win.Add(box);
        win.ShowAll();

        win.DeleteEvent += (o, e) => Application.Quit();
        Application.Run();
    }
}
