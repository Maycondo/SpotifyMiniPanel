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

        // Janela principal
        var win = new ContainerMain();
        win.Resizable = false;

        // Criação de widgets
        var progressBar = new ProgressBar();
        var settingsButton = new SettingsButton();
        var nextSongButton = new NextSongButton();
        var playAndPauseButton = new PlayAndPauseButton();
        var previousMusicButton = new PreviosMusicButton();

        // Caixa vertical geral
        VBox mainBox = new VBox(false, 20);

        // Top bar com botão de configurações à direita
        HBox topBar = new HBox();
        topBar.PackEnd(settingsButton, false, false, 0);
        mainBox.PackStart(topBar, false, false, 0);

        // Caixa para a progress bar
        HBox progressBox = new HBox();
        progressBox.BorderWidth = 10;
        progressBox.PackStart(new Label(), true, true, 0); // espaço à esquerda
        progressBar.WidthRequest = 260;  
        progressBar.HeightRequest = 2;
        progressBox.PackStart(progressBar, false, false, 0); // não expande
        progressBox.PackStart(new Label(), true, true, 0); // espaço à direita
        mainBox.PackStart(progressBox, false, false, 0);


        // Caixa de controle de música (centralizada)
        HBox musicControlBox = new HBox(true, 10);
        musicControlBox.PackStart(previousMusicButton, false, false, 0);
        musicControlBox.PackStart(playAndPauseButton, false, false, 10);
        musicControlBox.PackStart(nextSongButton, false, false, 0);

        HBox musicBoxAlign = new HBox();
        musicBoxAlign.PackStart(new Label(), true, true, 0); // Espaço à esquerda
        musicBoxAlign.PackStart(musicControlBox, false, false, 0);
        musicBoxAlign.PackStart(new Label(), true, true, 0); // Espaço à direita

        mainBox.PackStart(musicBoxAlign, false, false, 0);

        // Ação botão de configurações
        settingsButton.Clicked += (sender, e) =>
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

        // Ação botão play/pause
        playAndPauseButton.Clicked += (sender, e) =>
        {
            playAndPauseButton.TogglePlayPause();
        };

        // Finaliza
        win.Add(mainBox);
        win.ShowAll();

        // Posição da janela
        var screen = Display.Default.DefaultScreen;
        int width = 400;
        int height = 160;
        win.Resize(width, height);
        win.Move(screen.Width - width - 10, screen.Height - height - 40);

        win.DeleteEvent += (o, e) => Application.Quit();
        Application.Run();
    }
}
