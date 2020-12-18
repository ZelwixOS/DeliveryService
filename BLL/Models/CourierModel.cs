using DAL;

namespace BLL.Models
{

    public partial class CourierModel
    {
        public int ID { get; set; }

        public string CourierName { get; set; }

        public string PhoneNumber { get; set; }

        public CourierModel(Courier c)
        {
            ID = c.ID;
            CourierName = c.CourierName;
            PhoneNumber = c.PhoneNumber;
        }
        public CourierModel() { }
    }
}
