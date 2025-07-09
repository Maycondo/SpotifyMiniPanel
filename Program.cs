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
            


            

            // Cria a janela principal e os botões
            var win = new ContainerMain();
            var progressBar = new ProgressBar();

            var settingsButton = new SettingsButton(); 
            var nextSongButton = new NextSongButton(); 
            var playAndPauseButton = new PlayAndPauseButton(); 
            var previousMusicButton = new PreviosMusicButton();
            
            
            var alignmentProgressBox = new Alignment(0.5f, 0.3f, 0, 0);
            alignmentProgressBox.Add(progressBar);
            
            
            // Cria HBox com espaçamento entre os botões
            HBox musicControlBox = new HBox(true, 10);
            musicControlBox.PackStart(previousMusicButton, false, false, 0);
            musicControlBox.PackStart(playAndPauseButton, false, false, 0);
            musicControlBox.PackStart(nextSongButton, false, false, 0);

            // Centraliza horizontalmente com Alignment
            var alignment = new Alignment(0.5f, 0.5f, 0, 0);
            alignment.Add(musicControlBox);

            // Adiciona ao layout
            layout.Put(alignmentProgressBox, 120, 90);
            layout.Put(alignment, 92, 100); // Ajuste de posição (x, y)
            layout.Put(settingsButton, 348, 5); 

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

            // Ação do botão de play/pause
            playAndPauseButton.Clicked += (sender, e) =>
            {
                playAndPauseButton.TogglePlayPause();
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
