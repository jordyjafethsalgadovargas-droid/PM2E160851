namespace PM2E160851;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Esto le indica a la app que use el AppShell como la ventana principal
        return new Window(new AppShell());
    }
}