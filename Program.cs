using Gtk;
using SpotifyMiniPanel;
using SpotifyMiniPanel.UI.Windows;
using SpotifyMiniPanel.UI.Settings;

Gtk.Window? settingsWindow = null;

Application.Init();

var win = new MainWindow();
win.Resizable = false;

win.Realized += (_, __) =>
{
    SpotifyMiniPanel.Settings.LoadSettings();
    PositionSettings.ApplyWindowPosition(win);
};

// 🔹 UI
var imagemMusic = new ImagemMusic();
var nameMusic = new NameMusic();
var progressBar = new ProgressBar();
var settingsButton = new SettingsButton();
var nextSongButton = new NextSongButton();
var playAndPauseButton = new PlayAndPauseButton();
var previousMusicButton = new PreviosMusicButton();

VBox mainBox = new VBox(false, 3);

imagemMusic.MarginStart = 15;

HBox imagemNameBox = new HBox(false, 8);
VBox nameCenterBox = new VBox(false, 0);
nameCenterBox.Valign = Align.Center;
nameCenterBox.PackStart(nameMusic, false, false, 0);

imagemNameBox.PackStart(imagemMusic, false, false, 0);
imagemNameBox.PackStart(nameCenterBox, true, true, 0);

HBox topBar = new HBox();
topBar.PackEnd(settingsButton, false, false, 10);
mainBox.PackStart(topBar, false, false, 0);

mainBox.PackStart(imagemNameBox, false, false, 0);

VBox musicArea = new VBox(false, 4);

progressBar.WidthRequest = 270;
progressBar.HeightRequest = 2;

HBox progressBox = new HBox();
progressBox.PackStart(new Label(), true, true, 0);
progressBox.PackStart(progressBar, false, false, 0);
progressBox.PackStart(new Label(), true, true, 0);

HBox musicControl = new HBox(false, 14);
musicControl.PackStart(previousMusicButton, false, false, 0);
musicControl.PackStart(playAndPauseButton, false, false, 0);
musicControl.PackStart(nextSongButton, false, false, 0);

HBox centerButtons = new HBox();
centerButtons.PackStart(new Label(), true, true, 0);
centerButtons.PackStart(musicControl, false, false, 0);
centerButtons.PackStart(new Label(), true, true, 0);

musicArea.PackStart(progressBox, false, false, 0);
musicArea.PackStart(centerButtons, false, false, 0);
mainBox.PackStart(musicArea, false, false, 0);

win.Add(mainBox);

// 🔹 MOSTRA JANELA
win.ShowAll();


// 🔹 BOTÃO SETTINGS
settingsButton.Clicked += (s, e) =>
{
    if (settingsWindow == null || !settingsWindow.IsVisible)
    {
        settingsWindow = new SettingsWindow(win);
        settingsWindow.ShowAll();
    }
    else
    {
        settingsWindow.Hide();
        settingsWindow = null;
    }
};

// 🔹 FECHAR
win.DeleteEvent += (o, e) =>
{
    SpotifyMiniPanel.Settings.SaveSettings();
    Application.Quit();
};

Application.Run();
