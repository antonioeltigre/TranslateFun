using System.ComponentModel;
using System.Runtime.CompilerServices;

using TranslateFun.Annotations;

public class MainViewModel : INotifyPropertyChanged
{
    private string result;

    private bool translateButtonEnabled = true;

    public string TextToTranslate { get; set; } = "Hello";

    public string Result
    {
        get => this.result;
        set
        {
            if (value == this.result) return;
            this.result = value;
            this.OnPropertyChanged();
        }
    }

    public bool TranslateButtonEnabled
    {
        get
        {
            return this.translateButtonEnabled;
        }
        set
        {
            if (value == this.translateButtonEnabled) return;
            this.translateButtonEnabled = value;
            this.OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}