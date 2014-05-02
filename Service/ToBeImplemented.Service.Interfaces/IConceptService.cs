﻿using System.Collections.Generic;

namespace ToBeImplemented.Service.Interfaces
{
    using ToBeImplemented.Domain.Model;

    public interface IConceptService
    {
        List<Concept> GetAllConceptsWithAllCollections();

        Concept Details(long id);
    }
}
