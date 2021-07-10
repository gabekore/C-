using System.Collections.Generic;
using System.Linq;
using Interface;

namespace Server.WCF
{
    /// <summary>
    /// 公開メソッド
    /// </summary>
    public class Service : IService
    {
        public void CalcMinus(int a, int b, ref int result)
        {
            result = a - b;
        }

        public int CalcPlus(int a, int b)
        {
            return a + b;
        }

        // 戻り値に変数名付けてあるので、クライアント側でこの変数名がインテリセンスで出てくる
        public (string retStr, int retInt) UseTuple(string name, int age)
        {
            return ($"10年後の{name}さんの年齢は{age + 10}歳です。", age * 10);
        }

        public string HelloWorld(string name)
        {
            return $"ハロー, {name}'s ワールド3.";
        }

        public int[] UseArray(string[] numCharAry)
        {
            return numCharAry.Select(num => int.Parse(num) * 4)
                             .ToArray();
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

        // オーバーロードは使えない
        //public string HelloWorld(int num)
        //{
        //    return $"Hello, {num}'s World.";
        //}
    }
}
