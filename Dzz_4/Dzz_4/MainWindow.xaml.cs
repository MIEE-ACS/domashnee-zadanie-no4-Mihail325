using System;
using System.Collections.Generic;
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

namespace Dzz_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double[] array;
        uint N = 0u;
        private void bCreat_Click(object sender, RoutedEventArgs e)
        {
            if (uint.TryParse(tbcount.Text, out N) && N > 0)
            {
                if (N < 10000)
                {
                    array = new double[N];
                    Random random = new Random();
                    for (int i = 0; i < N; i++)
                    {
                        array[i] = Math.Round(-10 + random.NextDouble() * 20, 3);
                    }
                    var Array = array.Aggregate("", (res, x) => res += $" {x:0.000};").ToString();
                    tboutputM.Text = Array.Remove(Array.Length - 1);
                }
                else 
                {
                    MessageBox.Show("Не пугай деда!\nУ компьютера тоже может быть инсульта памяти.\nВозьми число поменьше.",
                        "Ошибка!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    tbcount.Clear();
                    tboutputM.Clear();
                }
            }
            else 
            {
                    MessageBox.Show("В данное поле можно вводить только натуральные числа!",
                        "Ошибка!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    tbcount.Clear();
                tboutputM.Clear();
            }
            

        }

        private void bsearchmin_Click(object sender, RoutedEventArgs e)
        {
            double min = array[0];
            for (int i = 1; i < N; i++) 
            { 
            if (min>array[i]) 
                    min = array[i];
            }
            tbMin.Text = String.Format($"{min:0.000}");
        }

        private void bSum_Click(object sender, RoutedEventArgs e)
        {
            int indexlastof=0, indexof=0;
            bool f1 = false, f2 = false;
            double sum=0;
            for (int i = 0; i < N; i++)
            {                
               
                if (array[i] > 0 && f1==false)
                {
                    indexof = i;
                    f1 = true;
                    continue;
                }
                if (array[i] > 0)
                {
                    indexlastof = i;
                    f2 = true;
                }
            }
            if (f1 == false)
                tbsum.Text = "В массиве нет положительных чисел";
            else if (f2 == false || N==1)
                tbsum.Text = "В массиве только одно положительно число";
            else if ((indexlastof - indexof) <= 1)
                tbsum.Text = "Первый и последний положительные элементы стоят рядом.";
            else
            {
                for (int i = indexof + 1; i < indexlastof; i++)
                    sum += array[i];
                tbsum.Text = String.Format($"{sum:0.000}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           //array[0] = 0; array[3] = 0; array[4] = 0; array[6] = 0; array[7] = 0; //-для проверки на нули;
            bool f1 = false;
            for (int i = 0; i < array.Length; i++) 
            {
                if (array[i] == 0)
                {
                    f1 = true;
                    break;
                }
            }
            if (f1 == false)
            {
                tbChangeMas.Text = array.Aggregate("", (res, x) => res += $" {x:0.000};");
                MessageBox.Show("В данном массиве нет нулей.\nМассив выведен без изменений. ",
                       "Замечание!",
                       MessageBoxButton.OK,
                       MessageBoxImage.Information);
            }
            else
            {
                var change = array.Where(x => x == 0).Concat(array.Where(x => x != 0)).ToArray();
                tbChangeMas.Text = change.Aggregate("", (res, x) => res += $" {x:0.000};");
            }
        }
    }
}


    
