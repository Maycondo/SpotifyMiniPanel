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

        var imagemMusic = new ImagemMusic();
        var nameMusic = new NameMusic();
        var progressBar = new ProgressBar();
        var settingsButton = new SettingsButton();
        var nextSongButton = new NextSongButton();
        var playAndPauseButton = new PlayAndPauseButton();
        var previousMusicButton = new PreviosMusicButton();

        // Caixa principal
        // Espaçamento vertical reduzido
        VBox mainBox = new VBox(false, 3);

        // Ajustes finos da imagem
        // Margens evitam encostar na borda
        imagemMusic.MarginStart = 15;

        // Caixa horizontal:
        // Imagem + Nome lado a lado
        HBox imagemNameBox = new HBox(false, 8);
        imagemNameBox.MarginBottom = 0;

        // Centralização vertical do nome
        // Sem Labels "falsos"
        VBox nameCenterBox = new VBox(false, 0);
        nameCenterBox.Valign = Align.Center; // 🔑 centralização correta
        nameCenterBox.PackStart(nameMusic, false, false, 0);

        // Adiciona imagem e nome
        imagemNameBox.PackStart(imagemMusic, false, false, 0);
        imagemNameBox.PackStart(nameCenterBox, true, true, 0);


        // Barra superior
        HBox topBar = new HBox();
        mainBox.PackStart(topBar, false, false, 0);
        topBar.PackEnd(settingsButton, false, false, 10);

        // Imagem + nome logo abaixo da top bar
        mainBox.PackStart(imagemNameBox, false, false, 0);

        // Área de controle da música
        VBox musicArea = new VBox(false, 4);

        // Barra de progresso
        progressBar.WidthRequest = 270;
        progressBar.HeightRequest = 2;

        HBox progressBox = new HBox();
        progressBox.PackStart(new Label(), true, true, 0);
        progressBox.PackStart(progressBar, false, false, 0);
        progressBox.PackStart(new Label(), true, true, 0);

        // Botões de controle
        HBox musicControl = new HBox(false, 14);
        musicControl.PackStart(previousMusicButton, false, false, 0);
        musicControl.PackStart(playAndPauseButton, false, false, 0);
        musicControl.PackStart(nextSongButton, false, false, 0);

        // Centralização horizontal dos botões
        HBox centerButtons = new HBox();
        centerButtons.PackStart(new Label(), true, true, 0);
        centerButtons.PackStart(musicControl, false, false, 0);
        centerButtons.PackStart(new Label(), true, true, 0);

        // Montagem da área inferior
        musicArea.PackStart(progressBox, false, false, 0);
        musicArea.PackStart(centerButtons, false, false, 0);

        // Margem inferior mínima
        musicArea.MarginBottom = 2;

        // Adiciona ao layout principal
        mainBox.PackStart(musicArea, false, false, 0);

        // Eventos
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

        // Janela
        win.Add(mainBox);
        win.ShowAll();

        var screen = Display.Default.DefaultScreen;
        win.Resize(400, 160);
        win.Move(screen.Width - 410, screen.Height - 200);

        win.DeleteEvent += (o, e) => Application.Quit();
        Application.Run();
    }
}
