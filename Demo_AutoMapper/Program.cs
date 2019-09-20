using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace Demo_AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();


            program.Run();
        }

        private void Run()
        {
            Customer customer = GetCustomerFromDB();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerViewItem1>());

            var mapper = new Mapper(config);
            CustomerViewItem1 customerVM = mapper.Map<CustomerViewItem1>(customer);
            customerVM.DateOfBirth = Convert.ToDateTime(customerVM.DateOfBirth.ToString()).ToLongDateString();

            //============TH mapping class thứ 3
            //CustomerViewItem _cus = GetCustomerViewItem();
            //config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerViewItem, CustomerViewItem1>());
            //mapper = new Mapper(config);
            //customerVM = mapper.Map<CustomerViewItem1>(_cus);


            ShowCustomerInDataGrid(customerVM);
        }
      


        private void ShowCustomerInDataGrid(CustomerViewItem1 customerViewItem) { }

        private Customer GetCustomerFromDB()
        {
            return new Customer()
            {
                DateOfBirth = new DateTime(1994, 11, 24),
                FirstName = "Phạm",
                LastName = "Thông",
                NumberOfOrders = 13,
                Company = new Company() { Name = "hwo.com" },
                VIP = true,
            };
        }

        private CustomerViewItem GetCustomerViewItem()
        {
            return new CustomerViewItem()
            {
                FullName = "Phạm Anh Thông",
            };
        }
    }

    public class Customer
    {
        public Company Company { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int NumberOfOrders { get; set; }

        public bool VIP { get; set; }

    }

    public class Company
    {
        public string Name { get; set; }
    }

    public class CustomerViewItem
    {
        public string CompanyName { get; set; }

        public string FullName { get; set; }
        //public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime DateOfBirth { get; set; }

        public string DateOfBirth { get; set; }

        public int NumberOfOrders { get; set; }

    }

    public class CustomerViewItem1
    {
        public string CompanyName { get; set; }

        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime DateOfBirth { get; set; }

        public string DateOfBirth { get; set; }

        public int NumberOfOrders { get; set; }

        public bool VIP { get; set; }
    }
}



