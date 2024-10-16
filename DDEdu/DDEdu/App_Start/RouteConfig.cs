using System.Web.Mvc;
using System.Web.Routing;

namespace DDEdu
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //Định tuyến đến trang Quên Mật Khẩu
            routes.MapRoute(
            name: "toForgot",
            url: "user/forgot",
            defaults: new { controller = "User", action = "forgotPassword" }
               );


            //Định tuyến khi nhấn nút Login
            routes.MapRoute(
            name: "toLogin",
            url: "user/login",
            defaults: new { controller = "User", action = "Login" }
               );

            //Định tuyến khi nhấn nút Registry
            routes.MapRoute(
            name: "toRegistry",
            url: "user/registry",
            defaults: new { controller = "User", action = "Register" }
               );

            //Định tuyến khi nhấn nút trang Profile
            routes.MapRoute(
            name: "toProfile",
            url: "user/profile",
            defaults: new { controller = "User", action = "UserInfo" }
               );


            //Định tuyến cho trang AboutUs có meta là about
            routes.MapRoute(
            name: "AboutUs",
            url: "about",
            defaults: new { controller = "AboutUs", action = "Index" }
               );

            // Định nghĩa cho đường dẫn /courses -> Courses/Index
            routes.MapRoute(
                name: "CourseIndex",
                url: "courses",
                defaults: new { controller = "Courses", action = "Index" }
            );

            // Định nghĩa đường dẫn cho courses/{meta} để hiển thị các category
            routes.MapRoute(
                name: "CategoryView",
                url: "courses/{metatitle}",
                defaults: new { controller = "Courses", action = "getViewByCategory" }
            );

            // Định nghĩa đường dẫn cho courses/{meta}/{id} để hiển thị chi tiết Course
            routes.MapRoute(
                name: "CourseDDetail",
                url: "courses/{metatitle}/{id}",
                defaults: new { controller = "Courses", action = "getDetail" }
            );

            // Định nghĩa đường dẫn cho news/{id} để hiển thị chi tiết New
            routes.MapRoute(
                name: "NewDetail",
                url: "news/{id}",
                defaults: new { controller = "News", action = "getNewDetail" }
            );



            // Route mặc định
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}