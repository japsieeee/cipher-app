using Hasher = AMS.Hasher.Hashers;

namespace CipherApp
{
    public partial class MainPage : ContentPage
    {
        string HashedValue;

        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnConvert_Clicked(object sender, EventArgs e)
        {
            BtnCopy.Text = "Copy";
            BtnCopy.IsEnabled = true;

            if (Editor.Text.Length > 0)
            {
                var rot13 = new Hasher.ROT13();
                HashedValue = rot13.Hash(Editor.Text);
                Label.Text = HashedValue;
                Frame.IsVisible = true;
            } else
            {
                Frame.IsVisible = false;
            }
        }

        private async void BtnCopy_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(HashedValue);
            BtnCopy.Text = "Copied";
            BtnCopy.IsEnabled = false;
        }
    }
}