using System.Collections.Generic;
using System.ServiceModel;
using ServiceIF.ObjIF;

/// <summary>
/// 参照設定で、System.ServiceModelが必要
/// </summary>
namespace ServiceIF.ApiIF
{
    public interface ICallbackType
    {
        [OperationContract(IsOneWay = true)]
        void CallbackFunction(
                    string push_id,
                    string param1,
                    int param2,
                    double param3,
                    string[] param4,
                    List<RetClass> param5);
    }
}
