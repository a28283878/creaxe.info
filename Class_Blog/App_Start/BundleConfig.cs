﻿using System.Web;
using System.Web.Optimization;

namespace Class_Blog
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/homeindex").Include(
                       "~/Scripts/Home/clean-blog.min.js",
                       "~/Scripts/Home/index.js",
                       "~/Scripts/jqBootstrapValidation.js"));

            bundles.Add(new ScriptBundle("~/bundles/ntustindex").Include(
                       "~/Scripts/Home/clean-blog.min.js",
                       "~/Scripts/jqBootstrapValidation.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/sweetalert.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/homeindex").Include(
                      "~/Content/font-awesome.min.css",
                       "~/Content/bootstrap.css",
                      "~/Content/clean-blog.min.css",
                        "~/Content/Home/index.css",
                        "~/Content/sweetalert.css"));

            bundles.Add(new StyleBundle("~/Content/ntustindex").Include(                     
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap.css",
                      "~/Content/clean-blog.min.css",
                      "~/Content/Ntust/index.css",
                        "~/Content/sweetalert.css"));
        }
    }
}
