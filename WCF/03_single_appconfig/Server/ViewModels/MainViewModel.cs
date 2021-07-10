using System;
using System.Reflection;
using System.ServiceModel;
using System.Windows.Threading;
using Interface;
using Server.WCF;

namespace Server.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //-------------------------------------------------
        // 変数
        //-------------------------------------------------
        //★App.config化により不要  private const string ServiceBaseAddr = @"http://localhost:8081/Gabekore";

        // 参照設定：System.ServiceModel.dll
        private ServiceHost serviceHost = null;

        //-------------------------------------------------
        // コンストラクタ
        //-------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dispatcher"></param>
        public MainViewModel(Dispatcher dispatcher)
        {
            //-------------------------------------------------
            // 画面コントロールの初期値
            //-------------------------------------------------
            BtnStartServiceEnabled = true;
            BtnStopServiceEnabled = false;
        }

        //-------------------------------------------------
        // プロパティ
        //-------------------------------------------------
        /// <summary>
        /// サービス開始ボタン、Enabledプロパティ
        /// </summary>
        private bool _btnStartServiceEnabled = false;
        public bool BtnStartServiceEnabled
        {
            get { return _btnStartServiceEnabled; }
            set
            {
                SetProperty(ref _btnStartServiceEnabled, value);
            }
        }

        /// <summary>
        /// サービス停止ボタン、Enabledプロパティ
        /// </summary>
        private bool _btnStopServiceEnabled = false;
        public bool BtnStopServiceEnabled
        {
            get { return _btnStopServiceEnabled; }
            set
            {
                SetProperty(ref _btnStopServiceEnabled, value);
            }
        }

        /// <summary>
        /// ログテキストボックス、Textプロパティ
        /// </summary>
        private string _txbLogText = string.Empty;
        public string TxbLogText
        {
            get { return _txbLogText; }
            set
            {
                SetProperty(ref _txbLogText, value);
            }
        }

        //-------------------------------------------------
        // WCFサービスオープン／クローズの処理
        //-------------------------------------------------
        /// <summary>
        /// サービス開始
        /// </summary>
        public void ServiceStart()
        {
            //---------------------------------------------------------
            // １．ServiceHostの作成
            //---------------------------------------------------------
            {
                Type serviceType = typeof(Service);
                //★App.config化により不要 Uri baseAddress = new Uri(ServiceBaseAddr);
                //★App.config化により変更 serviceHost = new ServiceHost(serviceType, baseAddress);
                serviceHost = new ServiceHost(serviceType);
            }

            //---------------------------------------------------------
            // ２．サービスのオープン
            //---------------------------------------------------------
            {
                // System.ServiceModel.AddressAccessDeniedException が発生したら、
                // コマンドプロンプト（←管理者モードで起動）で以下のコマンドを打つ
                // netsh http add urlacl url=http://+:8081/ user=hoge
                // ※hogeの部分はWindowsにログインしているユーザー名
                serviceHost.Open();
            }

            //---------------------------------------------------------
            // ログ表示
            //---------------------------------------------------------
            SetLog("サービス開始中");

            //---------------------------------------------------------
            // ボタンの制御
            //---------------------------------------------------------
            BtnStartServiceEnabled = false;
            BtnStopServiceEnabled = true;
        }

        /// <summary>
        /// サービス停止
        /// </summary>
        public void ServiceStop()
        {
            //---------------------------------------------------------
            // 事前のチェック（serviceHostの状態）
            //---------------------------------------------------------
            if (serviceHost == null)
            {
                return;
            }

            //---------------------------------------------------------
            // serviceHost終了
            //---------------------------------------------------------
            using (serviceHost)
            {
                serviceHost.Close();
            }
            serviceHost = null;

            //---------------------------------------------------------
            // ログ表示
            //---------------------------------------------------------
            SetLog("サービス停止中");

            //---------------------------------------------------------
            // ボタンの制御
            //---------------------------------------------------------
            BtnStartServiceEnabled = true;
            BtnStopServiceEnabled = false;
        }

        //-------------------------------------------------
        // Private
        //-------------------------------------------------
        /// <summary>
        /// ログ用テキストボックスにテキスト表示
        /// </summary>
        /// <param name="log"></param>
        private void SetLog(string log)
        {
            TxbLogText += (log + Environment.NewLine);
        }
    }
}
