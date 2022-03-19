using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CreditApplicationMVC.Models
{
    public class CreditsDbInitializer : DropCreateDatabaseIfModelChanges<CreditContext>
    {
        protected override void Seed(CreditContext context)
        {
            context.Credits.Add(new Credit { CreditName = "Ипотечный кредит", Period = 10, Amount = 1000000, Percent = 15 });
            context.Credits.Add(new Credit { CreditName = "Образовательный кредит", Period = 7, Amount = 300000, Percent = 10 });
            context.Credits.Add(new Credit { CreditName = "Потребительский кредит", Period = 5, Amount = 500000, Percent = 19 });
            base.Seed(context);
        }
    }
}