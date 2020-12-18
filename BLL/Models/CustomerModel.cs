using DAL;

namespace BLL.Models
{

    public partial class CustomerModel
    {
        public int ID { get; set; }

        public string CustomerName { get; set; }

        public double Discount { get; set; }
        
        public CustomerModel(Customer c)
        {
            ID = c.ID;
            CustomerName = c.CustomerName;
            Discount = c.Discount;
        }

        public CustomerModel()
        {

        }

    }
}
