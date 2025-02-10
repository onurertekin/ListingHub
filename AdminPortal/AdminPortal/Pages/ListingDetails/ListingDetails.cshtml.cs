using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Pages.ListingDetails
{
    public class ListingDetailsModel : PageModel
    {
        public void OnGet([FromRoute] string fieldTypeName, [FromRoute] int listingId)
        {
            ViewData["ListingId"] = listingId;

            if (fieldTypeName == "vasýta")
                ViewData["fieldType"] = 1;
            else if (fieldTypeName == "emlak")
                ViewData["fieldType"] = 2;
        }
    }
}
