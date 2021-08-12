using System;
using System.Windows.Forms;
using System.Windows.Threading;
using ClientCS.ViewModels;

namespace ClientCS
{
    public partial class MainView : Form
    {
        private MainViewModel _viewModel = new MainViewModel(Dispatcher.CurrentDispatcher);

        public MainView()
        {
            InitializeComponent();

            //---------------------------------------------------------
            // ViewModelとのバインディング
            // ※これはWCFとは無関係
            //---------------------------------------------------------
            TxbLog.DataBindings.Add(
                nameof(TxbLog.Text),
                _viewModel,
                nameof(_viewModel.TxbLogText));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnHelloWorld_Click(object sender, EventArgs e)
        {
            _viewModel.HelloWorld();
        }

        private void BtnCalcPlus_Click(object sender, EventArgs e)
        {
            _viewModel.CalcPlus();
        }

        private void BtnCalcMinus_Click(object sender, EventArgs e)
        {
            _viewModel.CalcMinus();
        }

        private void BtnUseTuple_Click(object sender, EventArgs e)
        {
            _viewModel.UseTuple();
        }

        private void BtnUseClass_Click(object sender, EventArgs e)
        {
            _viewModel.UseClass();
        }

        private void BtnUseListClass_Click(object sender, EventArgs e)
        {
            _viewModel.UseListClass();
        }

        private void BtnUseArray_Click(object sender, EventArgs e)
        {
            _viewModel.UseArray();
        }

        private void BtnOverLoad_Click(object sender, EventArgs e)
        {
            // オーバロードは使えない
            // _viewModel.UseOverLoad();
        }

        private void BtnCallbackRegist_Click(object sender, EventArgs e)
        {
            _viewModel.CallbackInitial();
        }
    }
}
