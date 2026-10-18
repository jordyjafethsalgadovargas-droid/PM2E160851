namespace PM2E160851
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            MainPage = new CalculadoraEnvios();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new CalculadoraEnvios());
        }

    }
}