using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace IldanTestApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        int widthMax = 1000;
        int heightMax = 1000;
        int widthMin = 20;
        int heightMin = 20;
        int topPad;
        int botPad;
        int leftPad;
        int rightPad;
        public HomePage()
        {
            InitializeComponent();
            drawStoryboard(10, 10, 10, 10);
        }

        public Image Img(string imgPath)
        {
            Image img = new Image();
            img.MaxWidth = widthMax;
            img.MaxHeight = heightMax;
            img.MinWidth = widthMin;
            img.MinHeight = heightMin;
            img.Margin = new Thickness(leftPad, topPad, rightPad, botPad);
            img.Source = new BitmapImage( new Uri(imgPath, UriKind.RelativeOrAbsolute));
            return img;
        }

        public void CreateElements()
        {
            var img1 = Img("/Images/1.jpg");
            var img2 = Img("/Images/2.jpg");
            var img3 = Img("/Images/3.jpg");
            var img5 = Img("/Images/5.jpg");
            var img7 = Img("/Images/7.jpg");
            var img8 = Img("/Images/8.jpg");

            var grid1 = new Grid();
            var grid2 = new Grid();
            var grid3 = new Grid();

            var r1 = CustomRowDefinition();
            var r2 = CustomRowDefinition();
            var r3 = CustomRowDefinition();
            var r4 = CustomRowDefinition();
            var r5 = CustomRowDefinition();
            var r6 = CustomRowDefinition();
            var r7 = CustomRowDefinition();

            var c1 = CustomColumnDefinition();
            var c2 = CustomColumnDefinition();
            var c3 = CustomColumnDefinition();
            var c4 = CustomColumnDefinition();
            var c5 = CustomColumnDefinition();
            var c6 = CustomColumnDefinition();
            var c7 = CustomColumnDefinition();

            Grid MyGrid = new Grid();

            MyGrid.Width = Double.NaN;
            MyGrid.Height = Double.NaN;
            MainGrid.Children.Add(MyGrid);
            MyGrid.RowDefinitions.Add(r1);

            MyGrid.ColumnDefinitions.Add(c1);
            MyGrid.ColumnDefinitions.Add(c2);
            MyGrid.ColumnDefinitions.Add(c3);

            MyGrid.Children.Add(img3);
            MyGrid.Children.Add(img5);
            MyGrid.Children.Add(grid1);
            r1.Height = new GridLength(200);
            r2.Height = new GridLength(100);

            grid1.RowDefinitions.Add(r2);
            grid1.RowDefinitions.Add(r3);
            grid1.ColumnDefinitions.Add(c4);
            grid1.Children.Add(grid2);
            grid1.Children.Add(img1);

            grid2.ColumnDefinitions.Add(c5);
            grid2.ColumnDefinitions.Add(c6);
            grid2.RowDefinitions.Add(r4);
            grid2.RowDefinitions.Add(r5);
            grid2.Children.Add(grid3);
            grid2.Children.Add(img7);

            grid3.RowDefinitions.Add(r6);
            grid3.RowDefinitions.Add(r7);
            grid3.Children.Add(img2);
            grid3.Children.Add(img8);

            r4.Height = new GridLength(100);
            r3.Height = new GridLength(100);
            r6.Height = new GridLength(50);
            r7.Height = new GridLength(50);

            // Элементы MyGrid
            Grid.SetRow(img3, 0);
            Grid.SetColumn(img3, 0);

            Grid.SetRow(img5, 0);
            Grid.SetColumn(img5, 2);

            Grid.SetRow(grid1, 0);
            Grid.SetColumn(grid1, 1);

            // Элементы grid1

            Grid.SetRow(grid2, 0);
            Grid.SetColumn(grid2, 0);

            Grid.SetRow(img1, 1);
            Grid.SetColumn(img1, 0);

            // Элементы grid2
            Grid.SetRow(img7, 0);
            Grid.SetColumn(img7, 0);

            Grid.SetRow(grid3, 0);
            Grid.SetColumn(grid3, 1);

            // Элементы grid3
            Grid.SetRow(img8, 0);
            Grid.SetColumn(img8, 0);

            Grid.SetRow(img2, 1);
            Grid.SetColumn(img2, 0);

        }

        public ColumnDefinition CustomColumnDefinition()
        {
            ColumnDefinition colDef = new ColumnDefinition();
            colDef.Width = new GridLength(1, GridUnitType.Auto);
            return colDef;
        }

        public RowDefinition CustomRowDefinition()
        {
            RowDefinition rowDef = new RowDefinition();
            rowDef.Height = new GridLength(1, GridUnitType.Auto);
            return rowDef;
        }

        public void drawStoryboard(int top, int right, int bot, int left)
        {
            topPad = top;
            botPad = bot;
            leftPad = left;
            rightPad = right;
            CreateElements();
        }

        private void UpdatePadBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NullCheck())
            {
                drawStoryboard(int.Parse(TopTB.Text), int.Parse(RightTB.Text), int.Parse(BotTB.Text), int.Parse(LeftTB.Text));
            }
            else
            {
                MessageBox.Show("Введите данные во все поля!");
            }
        }

        public bool NullCheck()
        {
            bool result = !string.IsNullOrEmpty(TopTB.Text)
                && !string.IsNullOrEmpty(RightTB.Text)
                && !string.IsNullOrEmpty(BotTB.Text)
                && !string.IsNullOrEmpty(LeftTB.Text);
            return result;
        }

        private void TopTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Regex.IsMatch(TopTB.Text, "[^0-9]"))
                {
                    throw new Exception();
                }
            }
            catch
            {
                TopTB.Text = TopTB.Text.Remove(TopTB.Text.Length - 1);
                TopTB.SelectionStart = TopTB.Text.Length;
                MessageBox.Show("Можно вводить только цифры!");
            }
        }

        private void RightTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Regex.IsMatch(RightTB.Text, "[^0-9]"))
                {
                    throw new Exception();
                }
            }
            catch
            {
                RightTB.Text = RightTB.Text.Remove(RightTB.Text.Length - 1);
                RightTB.SelectionStart = RightTB.Text.Length;
                MessageBox.Show("Можно вводить только цифры!");
            }
        }

        private void BotTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Regex.IsMatch(BotTB.Text, "[^0-9]"))
                {
                    throw new Exception();
                }
            }
            catch
            {
                BotTB.Text = BotTB.Text.Remove(BotTB.Text.Length - 1);
                BotTB.SelectionStart = BotTB.Text.Length;
                MessageBox.Show("Можно вводить только цифры!");
            }
        }

        private void LeftTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Regex.IsMatch(LeftTB.Text, "[^0-9]"))
                {
                    throw new Exception();
                }
            }
            catch
            {
                LeftTB.Text = LeftTB.Text.Remove(LeftTB.Text.Length - 1);
                LeftTB.SelectionStart = LeftTB.Text.Length;
                MessageBox.Show("Можно вводить только цифры!");
            }
        }
    }
}
