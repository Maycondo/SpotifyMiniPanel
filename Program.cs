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

        var win = new MainWindow(); // Cria a janela principal
        var settingsButton = new SettingsButton(); // Cria o botão de configuraçõeso
        layout.Put(settingsButton, 350, 5); // ajuste posição conforme largura da janela

        settingsButton.Clicked += (sender, e) =>
        {
            // Ação do botão de configurações
            Console.WriteLine("Botão de configurações clicado!");
            // Aqui você pode abrir uma nova janela ou exibir um diálogo de configurações
        };
    

        // VBox com conteúdo da interface
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
