using Gtk;

public class NameMusic : Box
{
    private Label labelMusic;

    // 🔹 Constructor
    public NameMusic() : base(Orientation.Vertical, 0)
    {
        //🔹 Label for Music Name
        labelMusic = new Label("Nome da Música");
        labelMusic.Name = "customLabel";
        labelMusic.Xalign = 0;

        PackStart(labelMusic, false, false, 0);
    
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            #customLabel {
                font-size: 14px;
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
