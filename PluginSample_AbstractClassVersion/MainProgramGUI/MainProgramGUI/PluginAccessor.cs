using PluginBaseDLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

// 参照の追加：PluginBaseDLL.dll
// このEXEと同じ階層のPluginフォルダにPluginSample1.dllとPluginSample2.dllを入れておく


namespace MainProgramGUI
{
    public class PluginAccessor
    {
        // 今回のサンプルではこのリストにPluginSample1.dllとPluginSample2.dllが登録される
        List<PluginBaseClass> _listPluginClass = new List<PluginBaseClass>();

        /// <summary>
        /// プラグインフォルダに入ってるプラグイン（DLL）を読み取る
        /// </summary>
        /// <returns>ロードできたDLLの個数</returns>
        public int LoadPlugins()
        {
            //---------------------------------------------------------------------------------
            // プラグインDLLの格納されたフォルダをEXEと同じ階層にあるPluginsフォルダとする
            //---------------------------------------------------------------------------------
            string strPluginFolder = Environment.CurrentDirectory + "\\Plugins";

            //---------------------------------------------------------------------------------
            // プラグインフォルダ内のDLLファイルを取得
            //---------------------------------------------------------------------------------
            // 今回のサンプルではPluginSample1.dllとPluginSample2.dllと取得できるはず
            string[] aryDllFilePath = Directory.GetFiles(strPluginFolder, "*.dll");

            //---------------------------------------------------------------------------------
            // PluginBaseClassの派生クラスのインスタンスを作成し、aryPluginBaseに追加
            //---------------------------------------------------------------------------------
            foreach (var sDLLFilePath in aryDllFilePath)
            {
                //---------------------------------------------------------------------------------
                // アセンブリをロード
                //---------------------------------------------------------------------------------
                var assembly = Assembly.LoadFile(sDLLFilePath);
                if (assembly == null)
                {
                    continue;
                }
                //---------------------------------------------------------------------------------
                // アセンブリ内の型定義を取得
                //---------------------------------------------------------------------------------
                Type[] types = assembly.GetTypes();
                //---------------------------------------------------------------------------------
                // PluginInterfaceまたはPluginBaseClassを継承するクラスをデフォルト
                // コンストラクタ経由でインスタンスを作成→各配列に追加する
                //---------------------------------------------------------------------------------
                foreach (var type in types)
                {
                    //-----------------------------------------------------------------------------
                    // クラス以外の型、抽象クラス、非公開クラス、外部利用不可なクラスは除く
                    //-----------------------------------------------------------------------------
                    if (!type.IsClass || type.IsAbstract || type.IsNotPublic || !type.IsVisible)
                    {
                        continue;
                    }
                    //-----------------------------------------------------------------------------
                    // ベースクラスPluginBaseClassを継承していることを確認
                    //-----------------------------------------------------------------------------
                    if (type.IsSubclassOf(typeof(PluginBaseClass)))
                    {
                        // (公開)デフォルトコンストラクタを取得
                        var ci = type.GetConstructor(Type.EmptyTypes);
                        if (ci == null)
                        {
                            // デフォルトコンストラクタが無いだとっ！？
                            continue;
                        }
                        // インスタンス作成
                        // カンケー無いけど、Invokeってのは呼び出すっていう意味
                        var instance = ci.Invoke(new object[] { });
                        if (instance == null)
                        {
                            // インスタンスを作成出来無いだとっ！？
                            continue;
                        }

                        // チェックを無事通ったものだけがリストに登録される
                        _listPluginClass.Add((PluginBaseClass)instance);
                    }
                }
            }

            //-----------------------------------------------------------------------------
            // GUIで動くことを指定
            //-----------------------------------------------------------------------------
            foreach (var plugin in _listPluginClass)
            {
                plugin.action_mode = PluginBaseClass.ACTION_MODE.GUI;
            }

            //-----------------------------------------------------------------------------
            // ロードできたDLLの個数を返す
            //-----------------------------------------------------------------------------
            return _listPluginClass.Count;
        }

        /// <summary>
        /// 全てのプラグインを実行する
        /// ※先にLoadPlugins()でプラグインを読み込んでいること
        /// </summary>
        public void AllPluginExec(TextWriter newOut)
        {
            foreach (var plugin in _listPluginClass)
            {
                plugin.SetOut(newOut);
                plugin.Show();
                plugin.SetNo(3);
                var ret = plugin.GetNo();
                Console.WriteLine($"[PluginAccessor] ret={ret}");
                Console.WriteLine("-------------");
            }
        }

        /// <summary>
        /// 個別にプラグインのShow()メソッドを実行
        /// ※先にLoadPlugins()でプラグインを読み込んでいること
        /// ※本来なら引数のidxDllのチェックが必要だが省略
        /// </summary>
        /// <param name="idxDll"></param>
        public void PluginShow(int idxDll)
        {
            _listPluginClass[idxDll].Show();
        }
        /// <summary>
        /// 個別にプラグインのSetNo()メソッドを実行
        /// ※先にLoadPlugins()でプラグインを読み込んでいること
        /// ※本来なら引数のidxDllのチェックが必要だが省略
        /// </summary>
        /// <param name="idxDll"></param>
        /// <param name="no"></param>
        public void PluginSetNo(int idxDll, int no)
        {
            _listPluginClass[idxDll].SetNo(no);
        }
        /// <summary>
        /// 個別にプラグインのGetNo()メソッドを実行
        /// ※先にLoadPlugins()でプラグインを読み込んでいること
        /// ※本来なら引数のidxDllのチェックが必要だが省略
        /// </summary>
        /// <param name="idxDll"></param>
        /// <returns></returns>
        public int PluginGetNo(int idxDll)
        {
            return _listPluginClass[idxDll].GetNo();
        }
    }
}
