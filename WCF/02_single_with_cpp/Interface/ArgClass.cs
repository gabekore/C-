using System.Runtime.Serialization;

/// <summary>
/// classには[DataContract]、プロパティには[DataMember]が必須
/// </summary>
namespace Interface
{
    // 参照設定：System.Runtime.Serialization
    [DataContract]
    public class ArgClass
    {
        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public string Kind { get; set; }

        public ArgClass(int price, string kind)
        {
            Price = price;
            Kind = kind;
        }
    }
}
