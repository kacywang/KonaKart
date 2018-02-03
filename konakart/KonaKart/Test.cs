using KonaKart.Pages;
using NUnit.Framework;
using NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonaKart
{
    class Test
    {

        [TestFixture]

        class Test1 : Base
        {
            [Test]
            public void Software_SearchMicrosoft()
            {
                test = extent.StartTest("Search Microsoft Under Software Category");
                Software obj = new Software();
                obj.SearchMicrosoft();
                obj.VerifySearch();
            }

            [Test]
            public void Cart_AddItem()
            {
                test = extent.StartTest("Add Items To Cart");
                Cart obj = new Cart();
                obj.AddItems();
                obj.VerifyCart();
                obj.VerifyPrice();
            }

            [Test]
            public void Cart_RemoveItem()
            {
                test = extent.StartTest("Remove Item And Update Cart");
                Cart obj = new Cart();
                obj.AddItems();
                obj.RemoveItem();
            }

            [Test]
            public void Cart_UseCoupon()
            {
                test = extent.StartTest("Use Coupon And Apply Discount");
                Cart obj = new Cart();
                obj.AddItems();
                obj.UseCoupon();
                obj.VerifyCoupon();

            }



        }






    }
}
