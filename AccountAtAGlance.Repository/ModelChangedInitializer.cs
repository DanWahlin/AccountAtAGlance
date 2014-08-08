using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAtAGlance.Repository
{
    public class ModelChangedInitializer :  DropCreateDatabaseIfModelChanges<AccountAtAGlanceContext>
    {
        protected override void Seed(AccountAtAGlanceContext context)
        {
            DataInitializer.Initialize(context);
            base.Seed(context);
        }
    }

}
