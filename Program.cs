using System;
using Gtk;
using Gdk;

class Program
{
    [Obsolete]
    static void Main(string[] args)
    {
        Application.Init();
        Fixed layout = new Fixed();

        var win = new ContainerMain(); // Cria a janela principal
        var settingsButton = new SettingsButton(); // Cria o botão de configuraçõeso
        layout.Put(settingsButton, 350, 5); // ajuste posição conforme largura da janela

        // Ação do botão de configurações
        settingsButton.Clicked += (sender, e) =>
        {
            var settingsWindow = new ContainerSettings(); // Cria a janela de configurações
            settingsWindow.ShowAll(); // Exibe a janela de configurações
    
        };
    

        // VBox com conteúdo da interface
        VBox box = new VBox();
        Label iconLabel = new Label("\uf04b"); // Unicode do ícone "play"
        iconLabel.Markup = "<span foreground='white' font='12'> 🎵 Nenhuma música tocando</span>";
        iconLabel.ModifyFont(Pango.FontDescription.FromString("Font Awesome 16"));


        Button playBtn = new Button("▶️ Tocar Música de Exemplo");
        playBtn.Clicked += (sender, e) =>
        {
            iconLabel.Markup = "<span foreground='lightgreen' font='12'>▶️ Tocando música de exemplo</span>";
        };

 

        box.PackStart(iconLabel, true, true, 5);
        box.PackStart(playBtn, false, false, 5);

        // Adiciona VBox ao layout, posicionando
        layout.Put(box, 10, 50); // (x, y)

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
