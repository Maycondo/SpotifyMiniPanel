using System;
using Gtk;
using Gdk;

class Program
{
    static Gtk.Window? settingsWindow = null;

    [Obsolete]
    static void Main(string[] args)
    {
        Application.Init();

        var win = new ContainerMain();
        win.Resizable = false;

        // Widgets
        var imagemMusic = new ImagemMusic();
        var nameMusic = new NameMusic();
        var progressBar = new ProgressBar();
        var settingsButton = new SettingsButton();
        var nextSongButton = new NextSongButton();
        var playAndPauseButton = new PlayAndPauseButton();
        var previousMusicButton = new PreviosMusicButton();

        // Caixa principal
        VBox mainBox = new VBox(false, 10);

        // Top bar (em cima)
        HBox topBar = new HBox();
        topBar.PackEnd(settingsButton, false, false, 10);
        mainBox.PackStart(topBar, false, false, 0);

        VBox imageNameBox = new VBox(false, 10);
        imageNameBox.PackStart(imagemMusic, false, false, 0);
        imageNameBox.PackStart(nameMusic, false, false, 0);


        // Espaço que empurra tudo para baixo
        mainBox.PackStart(new Label(), true, true, 0);

        // Área da música (embaixo)
        VBox musicArea = new VBox(false, 6);

        // Barra de progresso
        progressBar.WidthRequest = 270;
        progressBar.HeightRequest = 2;

        HBox progressBox = new HBox();
        progressBox.PackStart(new Label(), true, true, 0);
        progressBox.PackStart(progressBar, false, false, 0);
        progressBox.PackStart(new Label(), true, true, 0);

        // Botões
        HBox musicControl = new HBox(false, 14);
        musicControl.PackStart(previousMusicButton, false, false, 0);
        musicControl.PackStart(playAndPauseButton, false, false, 0);
        musicControl.PackStart(nextSongButton, false, false, 0);

        // Centralizar botões
        HBox centerButtons = new HBox();
        centerButtons.PackStart(new Label(), true, true, 0);
        centerButtons.PackStart(musicControl, false, false, 0);
        centerButtons.PackStart(new Label(), true, true, 0);

        // Montagem final da área de música
        musicArea.PackStart(progressBox, false, false, 0);
        musicArea.PackStart(centerButtons, false, false, 0);

        // Margem inferior
        musicArea.MarginBottom = 1;

        mainBox.PackStart(musicArea, false, false, 0);

        settingsButton.Clicked += (s, e) =>
        {
            if (settingsWindow == null || !settingsWindow.IsVisible)
            {
                settingsWindow = new ContainerSettings();
                settingsWindow.ShowAll();
            }
            else
            {
                settingsWindow.Hide();
                settingsWindow = null;
            }
        };

        playAndPauseButton.Clicked += (s, e) =>
        {
            playAndPauseButton.TogglePlayPause();
        };

        win.Add(mainBox);
        win.ShowAll();

        var screen = Display.Default.DefaultScreen;
        win.Resize(400, 160);
        win.Move(screen.Width - 410, screen.Height - 200);

        win.DeleteEvent += (o, e) => Application.Quit();
        Application.Run();
    }
}
