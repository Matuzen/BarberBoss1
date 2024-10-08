﻿using System.Globalization;

namespace BarberBoss.Api.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    public CultureMiddleware(RequestDelegate request)
    {
        _next = request;
    }

    public async Task Invoke(HttpContext context)
    {
        var culture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
        var cultureInfo = new CultureInfo("pt-BR");

        if (string.IsNullOrEmpty(culture) == false) 
        {
            cultureInfo = new CultureInfo(culture);
        }

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);

    }
}
