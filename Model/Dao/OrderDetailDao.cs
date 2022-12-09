using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.ViewModel;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        OnlineShopDbContext db = null;
        public OrderDetailDao()
        {
            db = new OnlineShopDbContext();
        }
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }

        public IEnumerable<OrderDetail> ListAllPaging(long OrderID, int page, int pageSize)
        {
            IQueryable<OrderDetail> model = db.OrderDetails;
            if (OrderID != 0)
            {
                model = model.Where(x => x.OrderID == OrderID);
            }

            return model.OrderByDescending(x => x.OrderID).ToPagedList(page, pageSize);
        }

        public bool Delete(int id)
        {
            try
            {
                var orderdetail = db.OrderDetails.Find(id);
                db.OrderDetails.Remove(orderdetail);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<OrderDetailViewModel> ListByOrderId(long ProductID, long OrderID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.OrderDetails.Where(x => x.OrderID == OrderID).Count();
            var model = (from a in db.OrderDetails
                         join b in db.Products
                         on a.ProductID equals b.ID
                         where a.ProductID == ProductID
                         join c in db.Orders
                         on a.OrderID equals c.ID
                         select new
                         {
                             ProductID = b.ID,
                             OrderID = c.ID,
                             Name = b.Name,
                             Image = b.Image,
                             Price = a.Price,
                             Quantity = b.Quantity
                         }).AsEnumerable().Select(x => new OrderDetailViewModel()
                         {
                             ProductID = x.ProductID,
                             OrderID = x.OrderID,
                             Name = x.Name,
                             Image = x.Image,
                             Price = x.Price,
                             Quantity = x.Quantity
                         });
            model.OrderByDescending(x => x.OrderID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}
