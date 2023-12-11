using System.Diagnostics;
using System.Windows;

namespace UI.View {
    /// <summary>
    ///     Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window {
        public AdminWindow() {
            InitializeComponent();
        }

        private void Debug_Click(object sender, RoutedEventArgs e) {
            Debug.WriteLine(DataContext.GetType().FullName);
        }
    }
}