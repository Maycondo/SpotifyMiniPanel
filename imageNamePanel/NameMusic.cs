using Gtk;

public class NameMusic : Box
{
    private Label labelMusic;

    public NameMusic() : base(Orientation.Vertical, 0)
    {
        labelMusic = new Label("Nome da Música");
        labelMusic.Name = "customLabel";
        labelMusic.Xalign = 0;

        PackStart(labelMusic, false, false, 0);

        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            #customLabel {
                font-size: 18px;
                font-weight: bold;
                color: #ffffff;
            }
        ");

       StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            StyleProviderPriority.Application
        );
        
        ShowAll();
    }

    public void SetMusicName(string name)
    {
        labelMusic.Text = name;
    }
}
