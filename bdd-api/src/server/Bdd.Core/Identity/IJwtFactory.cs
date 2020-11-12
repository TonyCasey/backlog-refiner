﻿using System.Collections.Generic;
using System.Security.Claims;

namespace Bdd.Core.Identity
{
    public interface IJwtFactory
    {
        string GenerateEncodedToken(string userId, string email, IEnumerable<Claim> additionalClaims);
    }
}
