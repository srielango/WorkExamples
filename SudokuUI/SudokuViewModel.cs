using GalaSoft.MvvmLight;

namespace SudokuUI
{
    public class SudokuViewModel : ViewModelBase
    {
        public int[,] Values { get; set; }

        public SudokuViewModel(int width)
        {
            Values = new int[width, width];
        }

        public int this[int i, int j]
        {
            get => Values[i, j];
            set => Set(ref Values[i, j], value);
        }
    }
}
