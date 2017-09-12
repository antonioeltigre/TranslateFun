namespace TranslateFun
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    public partial class MainWindow
    {
        private readonly MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {
            this.InitializeComponent();

            this.DataContext = this.viewModel;
        }

        private async void TranslateButtonClick(object sender, RoutedEventArgs e)
        {
            var cancellationToken = new CancellationTokenSource();

            this.viewModel.Result = string.Empty;


            var t = Task.Run(
                () =>
                    {
                        do
                        {
                            viewModel.Result += ".";
                            Thread.Sleep(100);
                        }
                        while (!cancellationToken.IsCancellationRequested);
                    }, cancellationToken.Token);



            this.viewModel.Result = await new MegaTranslator().TranslateLotsOfTimesAsync(this.viewModel.TextToTranslate, 10);


            cancellationToken.Cancel();
        }
    }
}