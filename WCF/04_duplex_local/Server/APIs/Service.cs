﻿using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using Server.ViewModels;
using ServiceIF;
using ServiceIF.ApiIF;
using ServiceIF.ObjIF;

namespace Server.APIs
{
    /// <summary>
    /// 公開メソッド
    /// </summary>
    /// <remarks>http://tuotehhou.y.ribbon.to/index.php?%2BWCF%2B%E5%8F%8C%E6%96%B9%E5%90%91%E9%80%9A%E4%BF%A1%E3%81%AB%E3%82%88%E3%82%8B%E3%82%B5%E3%83%BC%E3%83%90%E3%83%BC%E3%83%97%E3%83%83%E3%82%B7%E3%83%A5</remarks>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service : IService
    {
        public string HelloWorld(string name)
        {
            return $"Hello, {name}'s World.";
        }

        //// オーバーロードは使えない
        //public string HelloWorld(int num)
        //{
        //    return $"Hello, {num}'s World.";
        //}

        public int CalcPlus(int a, int b)
        {
            return a + b;
        }

        public void CalcMinus(int a, int b, ref int result)
        {
            result = a - b;
        }

        public (string retStr, int retInt) UseTuple(string name, int age)
        {
            return ($"10年後の{name}さんの年齢は{age + 10}歳です。", age * 10);
        }

        public ArgClass GetArgClass()
        {
            return new ArgClass(
                            price: 951,
                            kind: "AABBCC");
        }

        public RetClass UseClass(ArgClass argClass)
        {
            return new RetClass(
                            code: argClass.Price * 2,
                            name: $"[kind-{argClass.Kind}]");
        }

        public List<RetClass> UseListClass(List<ArgClass> argClass)
        {
            List<RetClass> ret = new List<RetClass>();

            argClass.ForEach(arg => ret.Add(new RetClass(
                                                    code: arg.Price * 3,
                                                    name: $"[KIND-{arg.Kind}]")));

            return ret;
        }

        public int[] UseArray(string[] numCharAry)
        {
            return numCharAry.Select(num => int.Parse(num) * 4)
                             .ToArray();
        }



        private ICallbackType _callbackType = null;
        private static object _lockObj = new object();
        public void CallbackRegist(string pid)
        {
            MessageBox.Show("コールバック登録あり");

            lock (_lockObj)
            {
                if (!MainViewModel.endPointManager.Keys.Contains(pid))
                {
                    // PIDが無いという事は初登場なので登録
                    MainViewModel.endPointManager.Add(
                                        pid,
                                        (
                                            param1,
                                            param2,
                                            param3,
                                            param4,
                                            param5
                                        ) =>
                                        {
                                            _callbackType.CallbackFunction(
                                                                    param1,
                                                                    param2,
                                                                    param3,
                                                                    param4,
                                                                    param5);
                                        }
                                       );
                }

                if (MainViewModel.endPointManager.Keys.Count > 0)
                {
                    _callbackType = OperationContext.Current.GetCallbackChannel<ICallbackType>();
                }
            }

            //if (MainViewModel.endPointManager.Keys.Count > 0)
            //{
            //    _callbackType = OperationContext.Current.GetCallbackChannel<ICallbackType>();
            //}
        }

    }
}