using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountBook.Models;

namespace AccountBook.ViewComponents
{
    /// <summary>
    /// 明細ヘッダーの一覧を表示するビューコンポーネントクラス。
    /// </summary>
    public class HeaderListSearchFormComponent : ViewComponent
    {
        
        private readonly MyContext myContext;

        public HeaderListSearchFormComponent(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(PaymentHeaderSearchCondition searchCondition)
        {

            //入力された検索条件から、明細を検索してViewへ渡す
            var searchResult = await SearchPaymentDataAsync(myContext, searchCondition);

            return View(searchResult);

        }

        /// <summary>
        /// 入力された検索条件から、明細データを検索して返します。
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PaymentHeader>> SearchPaymentDataAsync(MyContext context, PaymentHeaderSearchCondition searchCondition)
        {
            //検索対象のデータ
            var targetData = context.paymentHeaders;

            //明細の名称
            if(!String.IsNullOrEmpty(searchCondition.PaymentHeaderName))
            {
                targetData.Where(elem => elem.PaymentName.Contains(searchCondition.PaymentHeaderName));
            }

            //明細の総額From
            if(!(searchCondition.HeaderMoneyAmountFrom is null))
            {
                targetData.Where(elem => elem.MoneyAmount >= searchCondition.HeaderMoneyAmountFrom);
            }

            //明細の総額To
            if (!(searchCondition.HeaderMoneyAmountTo is null))
            {
                targetData.Where(elem => elem.MoneyAmount <= searchCondition.HeaderMoneyAmountTo);
            }

            //購入項目の額From
            if(!(searchCondition.DetailMoneyAmountFrom is null))
            {
                targetData.SelectMany(elem => elem.PaymentDetails)
                    .Where(elem => elem.MoneyAmount >= searchCondition.DetailMoneyAmountFrom);
            }

            //購入項目の額To
            if (!(searchCondition.DetailMoneyAmountTo is null))
            {
                targetData.SelectMany(elem => elem.PaymentDetails)
                    .Where(elem => elem.MoneyAmount >= searchCondition.DetailMoneyAmountTo);
            }

            //支払月の検索
            if (searchCondition.IsSearchActualMonth)
            {
                //実際の支払月を検索する
                
            }

            return targetData;

        }

    }
}
