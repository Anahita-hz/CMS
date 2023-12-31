﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using MyWeb.IocConfig;
using MyWeb.ServiceLayer.Contracts;
using MyWeb.ServiceLayer.EFServices.Users;
using Owin;
using StructureMap.Web;

namespace MyWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private static void ConfigureAuth(IAppBuilder appBuilder)
        {
            const int twoWeeks = 14;

            ProjectObjectFactory.Container.Configure(config => config.For<IDataProtectionProvider>()
                .HybridHttpOrThreadLocalScoped()
                .Use(() => appBuilder.GetDataProtectionProvider()));

            appBuilder.CreatePerOwinContext(
                () => ProjectObjectFactory.Container.GetInstance<ApplicationUserManager>());

            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                ExpireTimeSpan = TimeSpan.FromDays(twoWeeks),
                SlidingExpiration = true,
                CookieName = "MyWeb",
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity =
                            ProjectObjectFactory.Container.GetInstance<IApplicationUserManager>().OnValidateIdentity()
                }
            });

            ProjectObjectFactory.Container.GetInstance<IApplicationRoleManager>().SeedDatabase();

            ProjectObjectFactory.Container.GetInstance<IApplicationUserManager>().SeedDatabase();

            appBuilder.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            //appBuilder.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            // appBuilder.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);


            //appBuilder.UseFacebookAuthentication(
            //   appId: "fdsfdsfs",
            //   appSecret: "fdfsfs");

            //appBuilder.UseGoogleAuthentication(
            //    clientId: "fdsfsdfs",
            //    clientSecret: "fdsfsf");


        }
    }
}