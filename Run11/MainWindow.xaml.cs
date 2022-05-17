using MicaWPF;
using MicaWPF.Controls;
using MicaWPF.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Run11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MicaWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                WPFUI.Appearance.Watcher.Watch(
                  this,                           // Window class
                  WPFUI.Appearance.BackgroundType.Mica, // Background type
                  true                            // Whether to change accents automatically
                );
                
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(procs.Text);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                string filename = ofd.FileName;
                Process.Start(filename);
                this.Close();
            }
        }

        private void ThemeChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var themeService = ThemeService.GetCurrent();
            var tag_num = ThemeChanger.SelectedIndex;
            if (tag_num == 1)
                themeService.EnableMica(this, MicaWPF.BackdropType.Acrylic);
            else if (tag_num == 2)
                themeService.EnableMica(this, MicaWPF.BackdropType.Mica);
            else if (tag_num == 3)
                themeService.EnableMica(this, MicaWPF.BackdropType.Tabbed);
            else if (tag_num == 4)
                themeService.EnableMica(this, MicaWPF.BackdropType.None);
        }
    }
}
