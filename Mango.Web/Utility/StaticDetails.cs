﻿namespace Mango.Web.Utility
{
    public class StaticDetails
    {
        public static string CuponAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public enum ApiType {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
