using System.Windows;
using UI.ViewModel;
using Wpf.Ui.Controls;

namespace UI.View {
    /// <summary>
    ///     Interaction logic for CustomerForm.xaml
    /// </summary>
    public partial class CustomerFormWindow : Window {
        public CustomerFormWindow() {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e) {
            if (DataContext != null) {
                ((CustomerFormViewModel)DataContext).Customer.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}