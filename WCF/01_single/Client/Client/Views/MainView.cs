using System;
using System.Windows.Forms;
using System.Windows.Threading;
using Client.ViewModels;

namespace Client
{
    public partial class MainView : Form
    {
        private MainViewModel _viewModel = new MainViewModel(Dispatcher.CurrentDispatcher);

        /// <summary>
        /// コンストラクタ
        /// </summary>
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

        private void BtnGet10YearsAfter_Click(object sender, EventArgs e)
        {
            _viewModel.UsetTuple();
        }

        private void BtnUseClass_Click(object sender, EventArgs e)
        {
            _viewModel.UseClass();
        }

        private void BtnUseListClass_Click(object sender, EventArgs e)
        {
            _viewModel.UseListClass();
        }

        private void BtnNumCharToInteger_Click(object sender, EventArgs e)
        {
            _viewModel.UseArray();
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            _viewModel.StopService();
        }

        private void BtnOverLoad_Click(object sender, EventArgs e)
        {
            // オーバーロードは使えない
            // _viewModel.UseOverLoad();
        }
    }
}
