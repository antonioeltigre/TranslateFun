namespace TranslateFun
{
    using System.Windows;

    public partial class MainWindow
    {
        private readonly MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {
            this.InitializeComponent();

            this.DataContext = this.viewModel;
        }

        private void TranslateButtonClick(object sender, RoutedEventArgs e)
        {
            this.viewModel.Result = new MegaTranslator().TranslateLotsOfTimes(this.viewModel.TextToTranslate, 10);
        }
    }
}