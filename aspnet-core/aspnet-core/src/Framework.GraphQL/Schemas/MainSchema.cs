﻿using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using Framework.Queries.Container;

namespace Framework.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<QueryContainer>();
        }
    }
}