using DAL;

namespace BLL.Models
{
    
    public partial class TransportModel
    {
        public int ID { get; set; }

        public string TransportName { get; set; }

        public string Number { get; set; }

        public TransportModel(Transport t)
        {
            ID = t.ID;
            TransportName = t.TransportName;
            Number = t.Number;
        }

        public TransportModel() { }
    }
}
