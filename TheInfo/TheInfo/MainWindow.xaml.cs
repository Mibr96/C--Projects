using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Min(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_GitHub(object sender, RoutedEventArgs e)
        {
            string target = "https://github.com/Mibr96";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void TextBlock_LinkedIn(object sender, MouseButtonEventArgs e)
        {
            string target = "https://www.linkedin.com/in/mibru96/";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467260)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }

        }

        private void ProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            PopupProjects.IsOpen = true;
        }

        private void CertificationsButton_Click(object sender, RoutedEventArgs e)
        {
            PopupCertifications.IsOpen = true;
        }

        private void PopupCloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button closeButton)
            {
                // Check if the parent Popup of the clicked button is PopupProjects
                if (PopupProjects.IsOpen && closeButton.IsDescendantOf(PopupProjects.Child))
                {
                    PopupProjects.IsOpen = false; // Close PopupProjects
                }
                // Check if the parent Popup of the clicked button is PopupCertifications
                else if (PopupCertifications.IsOpen && closeButton.IsDescendantOf(PopupCertifications.Child))
                {
                    PopupCertifications.IsOpen = false; // Close PopupCertifications
                }
            }
        }

        private void PopupMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button minimizeButton)
            {
                // Check if the parent Popup of the clicked button is PopupProjects
                if (PopupProjects.IsOpen && minimizeButton.IsDescendantOf(PopupProjects.Child))
                {
                    PopupProjects.IsOpen = false; // Minimize PopupProjects
                }
                // Check if the parent Popup of the clicked button is PopupCertifications
                else if (PopupCertifications.IsOpen && minimizeButton.IsDescendantOf(PopupCertifications.Child))
                {
                    PopupCertifications.IsOpen = false; // Minimize PopupCertifications
                }
            }
        }

        private bool isDragging = false;
        private Point startPoint;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopupProjects.IsOpen = true;
        }

        private void Popup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = true;
                startPoint = e.GetPosition(PopupProjects);
            }
        }

        private void Popup_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var currentPoint = e.GetPosition(PopupProjects);
                var offset = currentPoint - startPoint;

                PopupProjects.HorizontalOffset += offset.X;
                PopupProjects.VerticalOffset += offset.Y;

                startPoint = currentPoint;
            }
        }

        private void Popup_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = false;
            }
        }
    }
}
