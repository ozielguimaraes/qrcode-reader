namespace BarCodeReader.Windows
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new BarCodeReader.App());
        }
    }
}
