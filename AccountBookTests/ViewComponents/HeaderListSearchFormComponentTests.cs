using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountBook.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using AccountBook.Models;

namespace AccountBook.ViewComponents.Tests
{
    [TestClass()]
    public class HeaderListSearchFormComponentTests
    {
        private MyContext myContext;

        public HeaderListSearchFormComponentTests()
        {
            //DBコンテキストの作成
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(databaseName: "UnitTestDb")
                .Options;
            this.myContext = new MyContext(options);

            myContext.AddRange(
                new PaymentHeader
                {
                    PaymentName = "SearchFormComponentTest_1"
                },
                new PaymentHeader
                {
                    PaymentName = "SearchFormComponentTest_2"
                },
                new PaymentHeader
                {
                    PaymentName = "AAAAA"
                },
                new PaymentHeader
                {
                    PaymentName = "VVVVVV"
                }, new PaymentHeader
                {
                    PaymentName = "TEST"
                }
            );

            myContext.SaveChanges();

            //テスト用のデータを作成する
            //this.myContext.Add(
            //    new PaymentHeader
            //    {
            //        PaymentHeaderId = 1,
            //        PaymentName = "SearchFormComponentTest_1",
            //        PaymentMonth = new DateTime(2020, 12, 1),
            //        ActuialPaymentMonth = new DateTime(2020, 12, 1),
            //        DataCreatedDate = new DateTime(2020, 12, 1),
            //        DataUpdateDate = new DateTime(2020, 12, 3),
            //        Memo = "Test1_Memo",
            //        MoneyAmount = 5000,
            //        AttachFile = null,
            //        User = new User
            //        {
            //            UserId = 1,
            //            Name = "TEST_1",
            //            MailAddress = "k_takahiro_150397@yahoo.co.jp",
            //            ProfilePicture = null
            //        },
            //        PaymentDetails = new List<PaymentDetail>()
            //        {
            //            new PaymentDetail()
            //            {
            //                PaymentDetailId = 1,
            //                PaymentType = new PaymentTypeMaster()
            //                {
            //                    PaymentTypeMasterId = 1,
            //                    PaymentTypeName = "家庭支出",
            //                    PaymentType = PaymentTypeMaster.PaymentTypeValue.Family,
            //                    IsCategoryChangable = true,
            //                    Category = new List<CategoryMaster>(){
            //                        new CategoryMaster()
            //                        {
            //                            CategoryMasterId = 1,
            //                            CategoryName = "日用品",
            //                            CategoryValue = 1
            //                        }
            //                    },
            //                    Group = PaymentTypeMaster.PaymentTypeGroup.FamilyGroup
            //                },
            //                Category = new CategoryMaster()
            //                {
            //                            CategoryMasterId = 1,
            //                            CategoryName = "日用品",
            //                            CategoryValue = 1
            //                },
            //                MoneyAmount = 3000,
            //                UnitPrice = 1500,
            //                UnitCount = 2,
            //                ItemName = "Detail_1",
            //                Memo ="Detail_1_Memo",
            //                TaxType = new TaxMaster()
            //                {
            //                    TaxMasterId = 1,
            //                    TaxName = "10%",
            //                    TaxRate = 10
            //                }
            //            },
            //            new PaymentDetail()
            //            {
            //                PaymentDetailId = 1,
            //                PaymentType = new PaymentTypeMaster()
            //                {
            //                    PaymentTypeMasterId = 1,
            //                    PaymentTypeName = "家庭支出",
            //                    PaymentType = PaymentTypeMaster.PaymentTypeValue.Family,
            //                    IsCategoryChangable = true,
            //                    Category = new List<CategoryMaster>(){
            //                        new CategoryMaster()
            //                        {
            //                            CategoryMasterId = 1,
            //                            CategoryName = "日用品",
            //                            CategoryValue = 1
            //                        }
            //                    },
            //                    Group = PaymentTypeMaster.PaymentTypeGroup.FamilyGroup
            //                },
            //                Category = new CategoryMaster()
            //                {
            //                            CategoryMasterId = 1,
            //                            CategoryName = "日用品",
            //                            CategoryValue = 1
            //                },
            //                MoneyAmount = 2000,
            //                UnitPrice = 200,
            //                UnitCount = 10,
            //                ItemName = "Detail_2",
            //                Memo ="Detail_2_Memo",
            //                TaxType = new TaxMaster()
            //                {
            //                    TaxMasterId = 1,
            //                    TaxName = "10%",
            //                    TaxRate = 10
            //                }
            //            },
            //        }
            //    }
            //    );
           
        }


        [TestMethod()]
        public void HeaderListSearchFormComponentTest()
        {




            Assert.Fail();
        }

        [TestMethod()]
        public void InvokeAsyncTest()
        {
            var testInstance = new HeaderListSearchFormComponent(myContext);

            //テスト用の検索条件
            var sCondition = new PaymentHeaderSearchCondition()
            {
                PaymentHeaderName = "test"
            };

            var result = testInstance.SearchPaymentDataAsync(myContext, sCondition).Result.ToList();


            Assert.IsTrue(
                result
                .Select(elem => elem.PaymentName)
                .Any(elem => elem.Contains("test"))
            );

            Assert.Fail();
        }
    }
}