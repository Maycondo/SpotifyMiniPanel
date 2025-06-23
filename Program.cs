using System;
using Gtk;
using Gdk;

class Program
{
    static Gtk.Window? settingsWindow = null; // Variável para armazenar a janela de configurações

    [Obsolete]
    static void Main(string[] args)
    {
        Application.Init();
        Fixed layout = new Fixed();

        var win = new ContainerMain(); // Cria a janela principal
        var settingsButton = new SettingsButton(); // Cria o botão de configuraçõeso
        var nextSongButton = new NextSongButton(); // Cria o botão de próxima música
        var previousMusicButton = new PreviosMusicButton(); // Cria o botão de música anterior
        layout.Put(previousMusicButton, 10, 100); // ajuste posição conforme largura da janela
        layout.Put(nextSongButton, 100, 100); // ajuste posição conforme largura da janela
        layout.Put(settingsButton, 348, 5); // ajuste posição conforme largura da janela

        // Ação do botão de configurações
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
                settingsWindow = null; // Limpa a variável quando a janela é fechada
            }
          
        };
    
        // VBox com conteúdo da interface
        VBox box = new VBox();




        // Adiciona VBox ao layout, posicionando
        layout.Put(box, 190, 100); // (x, y)


        // Adiciona o layout completo à janela
        win.Add(layout);
        win.ShowAll();

        // Posição da janela no canto inferior direito da tela
        var screen = Display.Default.DefaultScreen;
        int width = 300;
        int height = 100;
        win.Resize(width, height);
        win.Move(screen.Width - width - 10, screen.Height - height - 40);

        win.DeleteEvent += (o, e) => Application.Quit();
        Application.Run();
    }
}
