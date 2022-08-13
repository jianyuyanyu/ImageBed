﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using North.Common;
using System.Security.Claims;

namespace North.Pages.Auth
{
    partial class SignIn
    {
        [Parameter]
        [SupplyParameterFromQuery]
        public string Id { get; set; } = string.Empty;
        [Parameter]
        [SupplyParameterFromQuery]
        public string Redirect { get; set; } = string.Empty;


        /// <summary>
        /// 添加 Cookies
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            var identify = GlobalValues.UnitLoginIdentifies.Find(identify => identify.Id == Id);
            if ((_accessor.HttpContext is not null) && identify is not null)
            {
                GlobalValues.UnitLoginIdentifies.Remove(identify);
                await _accessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                        new ClaimsPrincipal(identify.ClaimsIdentity),
                                                        new AuthenticationProperties());
                _navigationManager.NavigateTo(Redirect, true);
            }
            _navigationManager.NavigateTo($"login?redirect={Redirect}", true);
        }
    }
}
