using System;
using System.Windows.Forms;
using System.Windows.Threading;
using Server.ViewModels;

namespace Server
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
            BtnStartService.DataBindings.Add(
                nameof(BtnStartService.Enabled),
                _viewModel,
                nameof(_viewModel.BtnStartServiceEnabled));
            BtnStopService.DataBindings.Add(
                nameof(BtnStartService.Enabled),
                _viewModel,
                nameof(_viewModel.BtnStopServiceEnabled));
            TxbLog.DataBindings.Add(
                nameof(TxbLog.Text),
                _viewModel,
                nameof(_viewModel.TxbLogText));
        }

        /// <summary>
        /// サービス開始ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartService_Click(object sender, EventArgs e)
        {
            _viewModel.ServiceStart();
        }

        /// <summary>
        /// サービス停止ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopService_Click(object sender, EventArgs e)
        {
            _viewModel.ServiceStop();
        }

        private void BtnCallback_Click(object sender, EventArgs e)
        {
            _viewModel.DoCallback();
        }
    }
}
