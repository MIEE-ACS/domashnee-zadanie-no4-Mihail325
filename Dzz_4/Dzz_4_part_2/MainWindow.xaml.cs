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

namespace Dzz_4_part_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        struct saddle
        {
            public int value;
            public int x;
            public int y;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        uint lines = 0, columns = 0;
        int[,] matrix;
        int Z;
        bool f1 = false, f2 = false,f3 = false;
        int t = 0, k = 0;
        string str2 = "";
        private void tbCreat_Click(object sender, RoutedEventArgs e)
        {
            int Max = 30;
            spEveryput.IsEnabled = false;
            try
            {
                lines = uint.Parse(tbCountLines.Text);
                Equalzero(lines);
                Over(lines, Max);
                f1 = true;
            }
            catch (OverflowException)
            {
                MessageBox.Show("В данное поле можно вводить только натуральные числа!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbCountLines.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("В данное поле можно вводить только натуральные числа!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbCountLines.Clear();
            }
            catch (EqualNull)
            {
                MessageBox.Show("Количество строк должно быть больше 0.",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbCountLines.Clear();
            }
            catch (OverlinesColumsn)
            {
                MessageBox.Show("Слишком большая матрица получится.\nУменьши количество строк.",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbCountLines.Clear();
            }
            try
            {
                columns = uint.Parse(tbCountColumns.Text);
                Equalzero(columns);
                Over(columns, Max);
                f2 = true;
            }
            catch (OverflowException)
            {
                MessageBox.Show("В данное поле можно вводить только натуральные числа!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbCountColumns.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("В данное поле можно вводить только натуральные числа!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbCountColumns.Clear();
            }
            catch (EqualNull)
            {
                MessageBox.Show("Количество столбцов должно быть больше 0.",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbCountColumns.Clear();
            }
            catch (OverlinesColumsn)
            {
                MessageBox.Show("Слишком большая матрица получится.\nУменьши количество столбцов.",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                tbCountColumns.Clear();
            }
            Random rand = new Random();
            if (f1 == true && f2 == true)
            {
                tbOutputPoint.Clear();
                tbOutputSum.Clear();
                matrix = new int[lines, columns];
                if (rbAuto.IsChecked == true)
                {

                    string str1 = "";
                    for (int i = 0; i < lines; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            matrix[i, j] = rand.Next(-100, 100);
                            str1 += ($"{matrix[i, j],5}").PadLeft(5) + "\t";
                        }
                        str1 += "\n";
                    }
                    tbMatrix.Text = str1.ToString();
                }
                else if (rbHand.IsChecked == true)
                {
                    spEveryput.IsEnabled = true;
                    tbMatrix.Clear();
                     f3 = false;
                     t = 0; k = 0;
                     str2 = "";
                    tbEverWelc.Text = $"Введите A(1,1) элемент:";
                }
                else
                {
                    MessageBox.Show("Необходимо выбрать как заполнять матрицу.",
                    "Внимание!",
                     MessageBoxButton.OK,
                     MessageBoxImage.Information);
                }
            }
        }
        private void bSum_Click(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            string str = "";
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        for (int k = 0; k < columns; k++)
                        {
                            sum += matrix[i, k];
                        }
                        str += $"Сумма в {i + 1}-ой строке =" + sum + "\n";
                        sum = 0;
                        break;
                    }
                }
            }
            if (str == "")
                tbOutputSum.Text = "В матрице нет отрицательных элементов";
            else
                tbOutputSum.Text = str;
        }

        private void bput_Click(object sender, RoutedEventArgs e)
        {
            f3 = true;
            while (f3 == true & t < lines)
            {
                while (f3 == true & k < columns)
                {
                    try
                    {
                        Z = int.Parse(tbEveryputelem.Text);
                        Over(Z, 10000);
                        tbEveryputelem.Clear();
                        matrix[t, k] = Z;
                        str2 += ($"{matrix[t, k],5}").PadLeft(5) + "\t";
                        f3 = false;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("В данное поле можно вводить только целые числа!",
                            "Ошибка!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        tbEveryputelem.Clear();
                    }
                    catch (Overvalue)
                    {
                        MessageBox.Show("Слишком большое число давай поменьше",
                            "Ошибка!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        tbEveryputelem.Clear();
                    }
                    if (f3 == false)
                    {
                        k++;
                        if (k!=columns)
                        tbEverWelc.Text = $"Введите A({t + 1},{k+1}) элемент:";
                    }
                    f3 = false;
                }
                if (k == columns)
                {
                    t++;
                    k = 0;
                    str2 += "\n";
                    if (t!=lines)
                    tbEverWelc.Text = $"Введите A({t + 1},{k + 1}) элемент:";
                }
            }
            if (t == lines)
            {
                tbMatrix.Text = str2.ToString();
                spEveryput.IsEnabled = false;
                MessageBox.Show("Матрица проинициализирована!",
                    "Поздравляем!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        //функцию рассчитывал из того что если в строке(столбце) два одинаковых элемента,
        //то это уже не минимум(не максимум) соответсвенно 
        private void bPoint_Click(object sender, RoutedEventArgs e)
        {
           saddle sed=new saddle();
            bool f4 = true, f5=true;
            string conclus = "";
            for (int i = 0; i < lines; i++)
            {
                f4 = true;f5 = true;
                sed.value = matrix[i, 0];
                sed.y = 0;
                sed.x = i;
                for (int j = 0; j < columns; j++)
                {
                    if (sed.value>matrix[i,j]) 
                    {
                        sed.value = matrix[i, j];
                        sed.y = j;
                        sed.x = i;
                    }
                }
                for (int z = 0; z < columns; z++) 
                {
                    if (sed.value == matrix[sed.x, z] && z!=sed.y)
                    {
                        f5 = false;f4 = false;
                        break;
                    }
                }
                if (f5 == true)
                {
                    for (int r = 0; r < lines; r++)
                    {
                        if (sed.value <= matrix[r, sed.y] && r!=sed.x)
                        {
                            f4 = false;
                            break;
                        }
                    }
                }
                if (f4==true && f5==true)
                conclus += $"Номер строки:{sed.x + 1}; Номер столбца:{sed.y + 1};\n";
            }
            if (conclus == "")
                tbOutputPoint.Text = "В данной матрице нет седловых точек";
            else
            tbOutputPoint.Text = conclus;
        }

        public class EqualNull : SystemException
        {
        }
        public class OverlinesColumsn : SystemException
        {
        }
        public class Overvalue: SystemException
        {
        }
        static void Equalzero(uint n)
        {
            if (n == 0)
                throw new EqualNull();
        }
        static void Over(uint n,int max)
        {
            if (n > max)
                throw new OverlinesColumsn();
        }
        static void Over(int n, int max)
        {
            if (n > max)
                throw new Overvalue();
        }

    }
}
