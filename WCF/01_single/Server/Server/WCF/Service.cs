using System.Collections.Generic;
using System.Linq;
using CommonInterface;

namespace Server.WCF
{
    /// <summary>
    /// 公開メソッド
    /// </summary>
    public class Service : IService
    {
        // オーバーロード使用不可
        // メソッド名が公開サービス名になるため、同名は区別できない

        public void CalcMinus(int a, int b, ref int result)
        {
            result = a - b;
        }

        public int CalcPlus(int a, int b)
        {
            return a + b;
        }

        public (string, int) Get10YearsAfter(string name, int age)
        {
            return ($"10年後の{name}さんの年齢は{age + 10}歳です。", age * 10);
        }

        public string HelloWorld(string name)
        {
            return $"Hello, {name}'s World.";
        }

        public int[] NumCharToInteger(string[] numCharAry)
        {
            return numCharAry.Select(num => int.Parse(num) * 4)
                             .ToArray();
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
    }
}
