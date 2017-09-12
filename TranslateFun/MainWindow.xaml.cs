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
            this.ButtonEnabled(false);
            await this.DoTranslation();
            this.ButtonEnabled(true);
        }

        private async Task DoTranslation()
        {
            var cancellationToken = new CancellationTokenSource();

            this.ClearResults();
            this.Dots(cancellationToken);
            this.viewModel.Result = await this.TranslatedResult();

            cancellationToken.Cancel();
        }

        private void ButtonEnabled(bool enabled) => this.viewModel.TranslateButtonEnabled = enabled;

        private async Task<string> TranslatedResult() => await new MegaTranslator().TranslateLotsOfTimesAsync(this.viewModel.TextToTranslate, 10);

        private void ClearResults() => this.viewModel.Result = string.Empty;

        private void Dots(CancellationTokenSource cancellationToken)
        {
            Task.Run(
                () =>
                    {
                        do
                        {
                            this.viewModel.Result += ".";
                            Thread.Sleep(100);
                        }
                        while (!cancellationToken.IsCancellationRequested);
                    },
                cancellationToken.Token);
        }
    }
}