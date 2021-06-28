using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Windows.Forms;
using System.Windows.Threading;
using CommonInterface;

namespace Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //-------------------------------------------------
        // 変数
        //-------------------------------------------------
        private const string ServiceBaseAddr = @"http://localhost:8081/Gabekore";
        private IService _service = null;
        private ChannelFactory<IService> _channel = null;

        //-------------------------------------------------
        // コンストラクタ
        //-------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dispatcher"></param>
        public MainViewModel(Dispatcher dispatcher)
        {
            base.Dispatcher = dispatcher;
        }

        //-------------------------------------------------
        // プロパティ
        //-------------------------------------------------
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
        /// WCFサービス開始
        /// </summary>
        public void StartService()
        {
            if (_service != null || _channel != null)
            {
                return;
            }

            try
            {
                // 参照設定：System.ServiceModel.dll
                EndpointAddress endpointAddr = new EndpointAddress(ServiceBaseAddr);

                // チャネルを構築しサービス呼び出しを行う.
                _channel = new ChannelFactory<IService>(new BasicHttpBinding());

                // サービスへのプロキシを取得.
                _service = _channel.CreateChannel(endpointAddr);
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }
        }

        /// <summary>
        /// WCFサービス終了
        /// </summary>
        public void StopService()
        {
            if (_service == null && _channel == null)
            {
                return;
            }

            using (_channel)
            {
                _channel.Close();
            }
            _service = null;
            _channel = null;
        }

        //-------------------------------------------------
        // WCFの公開メソッドをコール
        //-------------------------------------------------
        public void HelloWorld()
        {
            SetLog("-- ↓ --");

            StartService();

            try
            {
                // サービスメソッドの呼び出し.
                // string HelloWorld(string name);
                var result = _service.HelloWorld("Pochi");

                SetLog(result);
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }
            SetLog("-- ↑ --");
        }

        public void CalcPlus()
        {
            SetLog("-- ↓ --");

            StartService();

            try
            {
                // サービスメソッドの呼び出し.
                // int CalcPlus(int a, int b);
                var result = _service.CalcPlus(5, 6);

                SetLog(result.ToString());
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void CalcMinus()
        {
            SetLog("-- ↓ --");

            StartService();

            try
            {
                // サービスメソッドの呼び出し.
                // void CalcMinus(int a, int b, ref int result);
                int result = 0;
                _service.CalcMinus(5, 6, ref result);

                SetLog(result.ToString());
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void UsetTuple()
        {
            SetLog("-- ↓ --");

            StartService();

            try
            {
                // サービスメソッドの呼び出し.
                // (string, int) Get10YearsAfter(string name, int age);
                (var result1, var result2) = _service.UsetTuple("Pochi", 5);

                SetLog(result1+"/"+result2.ToString());
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void UseClass()
        {
            SetLog("-- ↓ --");

            StartService();

            try
            {
                // サービスメソッドの呼び出し.
                // RetClass UseClass(ArgClass argClass);
                var result = _service.UseClass(new ArgClass(123, "456"));

                SetLog(result.Code.ToString() + "/" + result.Name);
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void UseListClass()
        {
            SetLog("-- ↓ --");

            StartService();

            try
            {
                // サービスメソッドの呼び出し.
                // List<RetClass> UseListClass(List<ArgClass> argClass);
                var argClasss = new List<ArgClass>() {
                    new ArgClass(123, "abc"),
                    new ArgClass(456, "DEF"),
                    new ArgClass(789, "Ghi"),
                    new ArgClass(101112, "JkL"),
                };
                var result = _service.UseListClass(argClasss);

                result.ForEach(r => SetLog(r.Code.ToString() + "/" + r.Name));
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void UseArray()
        {
            SetLog("-- ↓ --");

            StartService();

            try
            {
                // サービスメソッドの呼び出し.
                // int[] NumCharToInteger(string[] numCharAry);
                var result = _service.UseArray(new string[] { "11","222","3333" });

                result.ToList().ForEach(r => SetLog(r.ToString()));
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }

        public void UseOverLoad()
        {
            SetLog("-- ↓ --");

            StartService();

            try
            {
                // サービスメソッドの呼び出し.
                // int[] NumCharToInteger(string[] numCharAry);
                var result = _service.UseOverLoad(9);

                SetLog(result.ToString());
            }
            catch (CommunicationException ex)
            {
                // エラー発生
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                MessageBox.Show(ex.Message);
                SetLog(ex.Message);
            }

            SetLog("-- ↑ --");
        }




        //-------------------------------------------------
        // Private
        //-------------------------------------------------
        /// <summary>
        /// ログ用テキストボックスにテキスト表示
        /// </summary>
        /// <param name="log"></param>
        private void SetLog(string log, [CallerMemberName]string mehodName = "unknown")
        {
            TxbLogText += $"{mehodName} : {log}{Environment.NewLine}";
        }
    }
}
