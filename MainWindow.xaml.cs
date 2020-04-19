using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace PixApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Bitmap picture = Properties.Resources.volvo;
        Bitmap picture_fin = Properties.Resources.volvo;

        private void Button1_Click(object sender, RoutedEventArgs e)  // загружаем файл
        {
            OpenFileDialog OFD = new OpenFileDialog();

            OFD.Filter = "Images (*.jpg)|*.jpg";
            bool? result = OFD.ShowDialog();
            if (result == true)
            {
              
                picture = new Bitmap(Bitmap.FromFile(OFD.FileName));
            }


                System.Windows.Media.Imaging.BitmapSource b =
    System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
           picture.GetHbitmap(),
           IntPtr.Zero,
           Int32Rect.Empty,
           BitmapSizeOptions.FromEmptyOptions());
            Image1.Source = b;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)  // запускаем преобразование
        {
            int itr = 1;
            try
            {
                itr = Int32.Parse(TextBox1.Text);
            }catch (System.FormatException sfe)
            {
                MessageBox.Show("Введи номальное число!","Ну что ж ты так!!!", MessageBoxButton.OK);
            }
            
            PixPrc PP = new PixPrc();
            Bitmap pix_fin = PP.ImgProc(picture,itr);
            System.Windows.Media.Imaging.BitmapSource b =
    System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
           pix_fin.GetHbitmap(),
           IntPtr.Zero,
           Int32Rect.Empty,
           BitmapSizeOptions.FromEmptyOptions());
            Image2.Source = b;

            picture_fin = pix_fin;
           
        }

        private void Button3_Click(object sender, RoutedEventArgs e)   // сохраняем файл
        {
            SaveFileDialog SFD = new SaveFileDialog();

            SFD.Filter = "Images (*.jpg)|*.jpg";
         
            bool? result = SFD.ShowDialog();
            if (result == true) {
                string path = SFD.FileName;

                try
                {
                    picture_fin.Save(path);
                }
                catch (Exception)
                {

                }

            }
            
            
        }
    }
}
