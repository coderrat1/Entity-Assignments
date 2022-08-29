using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementSystem.Models
{
    public class Repository
    {
        CMS_DBContext _dbContext;

        public Repository()
        {
            _dbContext = new CMS_DBContext();
        }

        #region Get All Customers
        public List<CUSTOMER> GetAllCustomers()
        {
            return _dbContext.CUSTOMERs.ToList();
        }
        #endregion

        #region Get Customer
        public CUSTOMER GetCustomer(int id)
        {
           return _dbContext.CUSTOMERs.FirstOrDefault(x => x.CustomerId == id);
        }
        
        public CUSTOMER GetCustomer(string name)
        {
            return _dbContext.CUSTOMERs.FirstOrDefault(x => x.CustomerName.StartsWith(name) && name.Trim().Length > 0);
        }
        #endregion

        #region Create Customer
        public int CreateCustomer(CUSTOMER customer)
        {
            try
            {
                CUSTOMER cust = new CUSTOMER
                {
                    CustomerName = customer.CustomerName.Trim(),
                    City = customer.City.Trim(),
                    Age = customer.Age,
                    Phone = customer.Phone,
                    PinCode = customer.PinCode
                };

                _dbContext.CUSTOMERs.Add(cust);
                _dbContext.SaveChanges();

                return cust.CustomerId;
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region Modify Customer
        public int ModifyCustomer(CUSTOMER customer, int id)
        {
            try
            {
                CUSTOMER c = _dbContext.CUSTOMERs.FirstOrDefault(x => x.CustomerId == id);
                if (c != null)
                {
                    c.CustomerName = customer.CustomerName;
                    c.City = customer.City;
                    c.Age = customer.Age;
                    c.Phone = customer.Phone;
                    c.PinCode = customer.PinCode;

                    _dbContext.SaveChanges();
                    return 1;
                }
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
            
        }

        public int ModifyCustomer(CUSTOMER customer, string name)
        {
            try
            {
                CUSTOMER c = _dbContext.CUSTOMERs.FirstOrDefault(x => x.CustomerName.StartsWith(name) && name.Trim().Length > 0);
                if (c != null)
                {
                    c.CustomerName = customer.CustomerName;
                    c.City = customer.City;
                    c.Age = customer.Age;
                    c.Phone = customer.Phone;
                    c.PinCode = customer.PinCode;

                    _dbContext.SaveChanges();
                    return 1;
                }
                else
                    return -1;
            }
            catch
            {
                return -1;
            }

        }
        #endregion

        #region Search Customer
        public CUSTOMER SearchCustomer(int id)
        {
            return _dbContext.CUSTOMERs.Find(id);
        }

        public CUSTOMER SearchCustomer(string name)
        {
            return _dbContext.CUSTOMERs.Find(name);
        }
        #endregion

        #region Remove Customer
        public int RemoveCustomer(int id)
        {
            try
            {
                CUSTOMER c = _dbContext.CUSTOMERs.Find(id);
                if (c != null)
                {
                    _dbContext.CUSTOMERs.Remove(c);
                    _dbContext.SaveChanges();
                    return 1;
                }
                else { return -1; }
            }
            catch
            {
                return -1;
            }
        }
        
        public int RemoveCustomer(string name)
        {
            try
            {
                CUSTOMER c = _dbContext.CUSTOMERs.FirstOrDefault(x => x.CustomerName.StartsWith(name) && name.Trim().Length > 0);
                if (c != null)
                {
                    _dbContext.CUSTOMERs.Remove(c);
                    _dbContext.SaveChanges();
                    return 1;
                }
                else { return -1; }
            }
            catch
            {
                return -1;
            }
        }
        #endregion

    }
}