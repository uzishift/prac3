using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MasEditor;
using LibCalc;
using System.Data.Common;

namespace prac2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flagCellEditEnding = false;
        bool flagDoneCellEditEnding = false;
        int[,] array;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Информация о программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №3. Вариант 12\nДана матрица размера M × N.\nНайти минимальный среди максимальных элементов ее столбцов.", "О программе");
        }
        /// <summary>
        /// Информация о разработчике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDev_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Демьяхин Роман ИСП-31", "Разработчик");
        }
        /// <summary>
        /// Кнопка закрытия программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Обработчик события редактирования таблицы, позволяет изменять значения DataGrid вручную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            flagCellEditEnding = true;
            int indexRow = e.Row.GetIndex();
            int indexColumn = e.Column.DisplayIndex;
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out int newValue))
            {
                flagDoneCellEditEnding = true;
                array[indexRow, indexColumn] = newValue;
            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Кнопка откытия таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            array = ArrayEditor.Open();
            dataGrid.ItemsSource = VisualArray.ToDataTable(array).DefaultView;
        }
        /// <summary>
        /// Кнопка сохранения таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ArrayEditor.Save(array);
        }
        /// <summary>
        /// Кнопка заполнения матрицы случайными числами, колличество строк и столбцов берется из tbCols и tbRows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbRows.Text, out int numberRow) && int.TryParse(tbCols.Text, out int numberColumn))
            {
                array = ArrayEditor.Fill(numberRow, numberColumn);
                dataGrid.ItemsSource = VisualArray.ToDataTable(array).DefaultView;
            }
            else MessageBox.Show("Введите корректные значения.", "Ошибка");
        }
        /// <summary>
        /// Кнопка очистки таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }
        /// <summary>
        /// Кнопка поиска минимального элемента в максимальном
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            if (array != null && flagCellEditEnding == flagDoneCellEditEnding)
            {
                tbRez.Text = LibCalculator.MinInMax(array).ToString();
            }
            else
            {
                MessageBox.Show("Введите значение в таблицу", "Ошибка");
            }
        }
    }
}