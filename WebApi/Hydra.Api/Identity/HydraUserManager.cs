using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydra.Api.Identity
{
    public class HydraUserManager : UserManager<HydraIdentityUser>
    {
        public HydraUserManager(IUserStore<HydraIdentityUser> store)
            : base(store)
        {

        }
    }
}