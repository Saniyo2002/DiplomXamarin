using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Api
{
    public static class RestApi
    {
        public static IRestApi restApi { get; set; }
        public static void Init()
        {
            restApi = RestService.For<IRestApi>(new System.Net.Http.HttpClient()
            {
                BaseAddress = new Uri("http://stuiomail-001-site1.dtempurl.com/")
            });
        }
    }
}
