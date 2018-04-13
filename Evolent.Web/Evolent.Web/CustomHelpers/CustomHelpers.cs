using System.Web.Mvc;

namespace Evolent.Web.CustomHelpers
{
    public static class CustomHelpers
    {
        public static MvcHtmlString YesNo(this HtmlHelper htmlHelper, bool yesNo)
        {
            var text = yesNo ? "Active" : "Inactive";
            return new MvcHtmlString(text);
        }

    }
}