using System.Collections.Generic;
using System.ServiceModel;
using ServiceIF.ObjIF;

/// <summary>
/// 参照設定で、System.ServiceModelが必要
/// </summary>
namespace ServiceIF.ApiIF
{
    [ServiceContract(CallbackContract=typeof(ICallbackType))]
    public interface IService
    {
        // 以下、公開サービスメソッド

        [OperationContract]
        string HelloWorld(string name);

        //// オーバロードは使えない
        //[OperationContract]
        //string HelloWorld(int num);

        [OperationContract]
        int CalcPlus(int a, int b);

        // refを使う
        [OperationContract]
        void CalcMinus(int a, int b, ref int result);

        // Tupleを使う（戻り値の名前はあってもなくてもどっちでもいいけどあった方が使い良い）
        [OperationContract]
        (string retStr, int retInt) UseTuple(string name, int age);

        // Classを使う
        [OperationContract]
        ArgClass GetArgClass();

        // Classを使う
        [OperationContract]
        RetClass UseClass(ArgClass argClass);

        // List<Class>を使う
        [OperationContract]
        List<RetClass> UseListClass(List<ArgClass> argClass);

        // 配列を使う
        [OperationContract]
        int[] UseArray(string[] numCharAry);

        [OperationContract(IsOneWay = true)]
        void CallbackRegist(string push_id);

    }
}
