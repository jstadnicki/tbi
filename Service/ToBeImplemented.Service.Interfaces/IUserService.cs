﻿namespace ToBeImplemented.Service.Interfaces
{
    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.Model.Users;

    public interface IUserService
    {
        long RegisterUser(RegisterUser isAny);
    }
}
