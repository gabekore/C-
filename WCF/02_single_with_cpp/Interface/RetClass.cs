using System.Runtime.Serialization;

/// <summary>
/// classには[DataContract]、プロパティには[DataMember]が必須
/// </summary>
namespace Interface
{
    // 参照設定：System.Runtime.Serialization
    [DataContract]
    public class RetClass
    {
        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        public RetClass(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
