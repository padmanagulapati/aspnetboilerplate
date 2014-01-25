﻿using System.Reflection;
using Abp.Application.Authorization;
using Abp.Application.Authorization.Permissions;
using Abp.Application.Services;
using Abp.Application.Services.Dto.Validation;
using Abp.Dependency;
using Abp.Modules;
using Abp.Utils.Extensions;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;

namespace Abp.Startup.Application
{
    /// <summary>
    /// This module is used to simplify and standardize building the "Application Layer" of an application.
    /// </summary>
    [AbpModule("Abp.Application")]
    public class AbpApplicationModule : AbpModule
    {
        public override void PreInitialize(IAbpInitializationContext initializationContext)
        {
            base.PreInitialize(initializationContext);
            ApplicationLayerInterceptorRegisterer.Initialize(initializationContext);
        }

        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocHelper.Resolve<IPermissionManager>().Initialize();
        }
    }
}
