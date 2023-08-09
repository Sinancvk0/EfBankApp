using Microsoft.AspNetCore.Razor.TagHelpers;
using SC.BankApp.Web.Data.Context;
using System.Linq;

namespace SC.BankApp.Web.TagHelpers
{
    [HtmlTargetElement("getAccountCount")]
    public class GetBankAccountCount : TagHelper
    {
        public int ApplicationUserId { get; set; }
        private readonly BankContext _context;

        public GetBankAccountCount(BankContext context)
        {
            _context = context;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x => x.ApplicationUserId == ApplicationUserId);
            var html = $"<span class='badge bg-danger'>{accountCount}</span>";
            output.Content.SetHtmlContent(html); // Html içeriğini ekliyoruz
        }
    }
    
}
