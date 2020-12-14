using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AccountBook.Helpers
{
    public static class DisplayColumnNameForHelperExtensions
    {
        public static string DisplayColumnNameFor<TModel, TClass, TProperty>(this IHtmlHelper<TModel> helper, IEnumerable<TClass> model, Expression<Func<TClass, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            name = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var metadata = ModelMetadataProviders.Current.GetMetadataForProperty(
                () => Activator.CreateInstance<TClass>(), typeof(TClass), name);

            return metadata.DisplayName;
        }

    }
}
