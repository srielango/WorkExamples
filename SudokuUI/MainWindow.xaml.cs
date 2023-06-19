using SudokuSolver;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace SudokuUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const int InnerWidth = 3;
        private const int OuterWidth = InnerWidth * InnerWidth;

        private const int Thin = 1;
        private const int Thick = 3;

        public SudokuViewModel ViewModel => (SudokuViewModel)DataContext;
        public MainWindow()
        {
            InitializeComponent();
            InitializeViewModel();
            InitializeSudokuTable();
            AddTestData();
        }

        private void InitializeViewModel()
        {
            DataContext = new SudokuViewModel(OuterWidth);
        }

        private void InitializeSudokuTable()
        {
            var grid = new UniformGrid
            {
                Rows = OuterWidth,
                Columns = OuterWidth
            };

            for (var i = 0; i < OuterWidth; i++)
            {
                for (var j = 0; j < OuterWidth; j++)
                {
                    var border = CreateBorder(i, j);
                    border.Child = CreateTextBox(i, j);
                    grid.Children.Add(border);
                }
            }

            SudokuTable.Child = grid;
        }

        private Border CreateBorder(int i, int j)
        {
            var left = j % InnerWidth == 0 ? Thick : Thin;
            var top = i % InnerWidth == 0 ? Thick : Thin;
            var right = j == OuterWidth - 1 ? Thick : 0;
            var bottom = i == OuterWidth - 1 ? Thick : 0;

            return new Border
            {
                BorderThickness = new Thickness(left, top, right, bottom),
                BorderBrush = Brushes.Black
            };
        }

        private TextBox CreateTextBox(int i, int j)
        {
            var textBox = new TextBox
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 15,
                BorderBrush = Brushes.White
            };

            var binding = new Binding
            {
                Source = ViewModel,
                Path = new PropertyPath($"[{i},{j}]"),
                Mode = BindingMode.TwoWay
            };

            textBox.SetBinding(TextBox.TextProperty, binding);

            return textBox;
        }

        private void Solve_Click(object sender, RoutedEventArgs e)
        {
            BacktrackingSudokuSolver ss = new BacktrackingSudokuSolver();

            ss.InitializeGrid(ViewModel.Values);
            ss.Solve();
            ViewModel.Values = ss.GetValues();
        }

        private void AddTestData()
        {
            var testData = new int[9, 9];
            testData[0, 0] = 3;
            testData[0, 7] = 1;

            testData[1, 0] = 9;
            testData[1, 3] = 5;
            testData[1, 4] = 8;
            testData[1, 5] = 7;
            testData[1, 6] = 6;

            testData[2, 2] = 4;
            testData[2, 6] = 5;
            testData[2, 8] = 7;

            testData[3, 1] = 9;
            testData[3, 4] = 1;
            testData[3, 8] = 6;

            testData[4, 1] = 4;
            testData[4, 3] = 3;
            testData[4, 4] = 6;
            testData[4, 5] = 9;
            testData[4, 7] = 7;

            testData[5, 0] = 1;
            testData[5, 4] = 7;
            testData[5, 7] = 3;

            testData[6, 0] = 2;
            testData[6, 2] = 7;
            testData[6, 6] = 3;

            testData[7, 2] = 6;
            testData[7, 3] = 7;
            testData[7, 4] = 2;
            testData[7, 5] = 8;
            testData[7, 8] = 9;

            testData[8, 1] = 1;
            testData[8, 8] = 2;

            for(var i = 0; i < 9; i++)
            {
                for(var j = 0; j < 9; j++)
                {
                    ViewModel[i,j] = testData[i,j];
                }
            }
        }
    }

    
}
