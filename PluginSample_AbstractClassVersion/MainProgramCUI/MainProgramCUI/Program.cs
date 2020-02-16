using System;

namespace MainProgramCUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // プラグインをロードして実行
            var plugin = new PluginAccessor();
            var numDll = plugin.LoadPlugins();
            Console.WriteLine($"[Main] numDll={numDll}");
            Console.WriteLine("");


            Console.WriteLine("[Main] 全てのプラグイン実行=========");
            plugin.AllPluginExec();
            Console.WriteLine("");


            Console.WriteLine("[Main] 1つ目のプラグイン実行=========");
            var idxDll = 0;
            plugin.PluginShow(idxDll);
            plugin.PluginSetNo(idxDll, 5);
            var getno = plugin.PluginGetNo(idxDll);
            Console.WriteLine($"[Main] getno1={getno}");
            Console.WriteLine("");


            Console.WriteLine("[Main] 2つ目のプラグイン実行=========");
            idxDll = 1;
            plugin.PluginShow(idxDll);
            plugin.PluginSetNo(idxDll, 7);
            getno = plugin.PluginGetNo(idxDll);
            Console.WriteLine($"[Main] getno2={getno}");
            Console.WriteLine("");


            // 処理結果を見るために、コンソール画面が落ちないように一時停止
            Console.ReadLine();
        }
    }
}
