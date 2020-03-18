﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Ninject;
using SportsStore.Infrastructure.Abstract;
using SportsStore.Infrastructure.Concrete;

 namespace SportsStore.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel
                .Bind<IProductRepository>()
                .To<EFProductRepository>();
            
            EmailSettings emailSettings = new EmailSettings()
            {
                MailToAddress = ""
            };

            kernel
                .Bind<IOrderProcessor>()
                .To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);

            kernel
                .Bind<IAuthProvider>()
                .To<FormsAuthProvider>();
        }
    }
}