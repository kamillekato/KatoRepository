using BusinessLogicLibrary.Entities;
using EFModelLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class BusinessLogic
    {
        public List<Exception> ExceptionList = new List<Exception>();

        public List<SalesReason> DisplayAllSalesReason()
        {
            List<SalesReason> salesReasons = new List<SalesReason>();

            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    salesReasons = (from salesReason in context.SalesReasons
                                   orderby salesReason.Name
                                   select salesReason
                                   ).ToList() ; 
                }
            }
            catch (Exception ex)
            {
                ExceptionList.Add(ex);
                salesReasons = null;
            }

            return salesReasons;
        }

        public bool CheckIfIdIsExisting(int id)
        {
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    var result = context.SalesReasons.Any(x => x.SalesReasonID == id);
                    return result;
                }
            }   
            catch (Exception ex)
            {
                ExceptionList.Add(ex);
                return false;
            }
        }
        public SalesReason DisplaySalesReason(int id)
        {
            SalesReason salesReason = new SalesReason();

            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    var result = context.SalesReasons
                        .Where(x => x.SalesReasonID == id)
                        .Select(x => x).SingleOrDefault();
                    salesReason = result;
                }
            }
            catch (Exception ex)
            {
                ExceptionList.Add(ex);
                salesReason = null;
            }
            return salesReason;
        }

        public bool AddSalesReason(SalesReason newSalesReason)
        {
            int returnValue = 0;
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    newSalesReason.ModifiedDate = DateTime.Now;
                    context.SalesReasons.Add(newSalesReason);
                    returnValue = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ExceptionList.Add(ex);
                returnValue = 0;
            }
            return returnValue != 0;          
        }

        public bool UpdateSalesReason(SalesReason salesReasonUpdate)
        {
            int returnValue = 0;

            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    //SalesReason salesReason = (from sReason in context.SalesReasons
                    //                           where sReason.SalesReasonID == salesReasonUpdate.SalesReasonID
                    //                           select sReason).SingleOrDefault(); 
                    //salesReason.Name = salesReasonUpdate.Name;
                    //salesReason.ReasonType = salesReasonUpdate.ReasonType;
                    salesReasonUpdate.ModifiedDate = DateTime.Now;
                    //returnValue = context.SaveChanges();
                    context.Entry(salesReasonUpdate).State = System.Data.Entity.EntityState.Modified;
                    returnValue = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ExceptionList.Add(ex);
                returnValue = 0;
            }

            return returnValue != 0;
        }

        public bool DeleteSalesReason(int id)
        {
            int returnValue = 0;
            try
            {
                using (var context =  new AdventureWorks2008Entities())
                {
                    SqlParameter[] parameter = new SqlParameter[]
                    {
                    new SqlParameter("ID" , id)
                    };
                    returnValue = context.Database.ExecuteSqlCommand("Delete from sales.salesReason WHERE SalesReasonID = @ID ",parameter);
                }
            }
            catch (Exception ex)
            {
                ExceptionList.Add(ex);
                returnValue = 0;
            }

            return returnValue != 0;
        }

        public int CountSalesReason()
        { 
            try
            {
                using (var context = new AdventureWorks2008Entities())
                { 
                    var result = context.Database.SqlQuery<int>("select count(*) from sales.salesreason").SingleOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                ExceptionList.Add(ex);
                return 0;
            }
        }

        public List<EmployeeModel> DisplayEmployeeManagers(int id)
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    SqlParameter[] parameter = new SqlParameter[]
                    {
                    new SqlParameter("ID" , id)
                    };
                    employeeList = context.Database.SqlQuery<EmployeeModel>("Exec dbo.uspGetEmployeeManagers @ID",parameter).ToList();
 
                    
                }
            }
            catch (Exception ex)
            {
                ExceptionList.Add(ex);
                employeeList = null;
            }

            return employeeList;
        }




    }
}
