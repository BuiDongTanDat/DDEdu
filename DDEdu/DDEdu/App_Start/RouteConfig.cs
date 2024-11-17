using DDEdu.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace DDEdu
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            
            //Định tuyến thực thi hủy đăng ký khóa học
            routes.MapRoute(
            name: "unsubscribeCourse",
            url: "courses/unsubscribe/{id}",
            defaults: new { controller = "MyCourses", action = "unsubscribeCourse" },
            namespaces: new[] { "DDEDu.Controllers" }
               );


            //Định tuyến thực thi đăng ký khóa học
            routes.MapRoute(
            name: "registerCourse",
            url: "courses/registercourse/{id}",
            defaults: new { controller = "Courses", action = "RegisterCourse" },
            namespaces: new[] { "DDEDu.Controllers" }
               );


            //Định tuyến khi nhấn nút Log out
            routes.MapRoute(
            name: "toLogout",
            url: "user/logout",
            defaults: new { controller = "User", action = "Logout" },
            namespaces: new[] { "DDEDu.Controllers" }
               );


            //Định tuyến khi nhấn nút Đổi thông tin
            routes.MapRoute(
            name: "toChangeProfile",
            url: "user/changeprofile",
            defaults: new { controller = "User", action = "changeProfile" },
            namespaces: new[] { "DDEDu.Controllers" }
               );


            //Định tuyến khi nhấn nút Đổi mật khẩu
            routes.MapRoute(
            name: "toChangepassword",
            url: "user/changePassword",
            defaults: new { controller = "User", action = "changePassword" },
            namespaces: new[] { "DDEDu.Controllers" }
               );

            //Định tuyến đến trang Quên Mật Khẩu
            routes.MapRoute(
            name: "toForgot",
            url: "user/forgot",
            defaults: new { controller = "User", action = "forgotPassword" },
            namespaces: new[] { "DDEDu.Controllers" }
               );


            //Định tuyến khi nhấn nút Login
            routes.MapRoute(
            name: "toLogin",
            url: "user/login",
            defaults: new { controller = "User", action = "Login" },
            namespaces: new[] { "DDEDu.Controllers" }
               );

            //Định tuyến khi nhấn nút Registry
            routes.MapRoute(
            name: "toRegistry",
            url: "user/registry",
            defaults: new { controller = "User", action = "Register" },
            namespaces: new[] { "DDEDu.Controllers" }
               );

            //Định tuyến khi nhấn nút trang Profile
            routes.MapRoute(
            name: "toProfile",
            url: "user/profile",
            defaults: new { controller = "User", action = "UserInfo" },
            namespaces: new[] { "DDEDu.Controllers" }
               );


            //Định tuyến cho trang AboutUs có meta là about
            routes.MapRoute(
            name: "AboutUs",
            url: "about-us",
            defaults: new { controller = "AboutUs", action = "Index" },
            namespaces: new[] { "DDEDu.Controllers" }
               );

            // Định nghĩa cho đường dẫn /courses -> Courses/Index
            routes.MapRoute(
                name: "CourseIndex",
                url: "courses",
                defaults: new { controller = "Courses", action = "Index" },
                namespaces: new[] { "DDEDu.Controllers" }
            );

            // Định nghĩa đường dẫn cho courses/{meta} để hiển thị các category
            routes.MapRoute(
                name: "CategoryView",
                url: "courses/{metatitle}",
                defaults: new { controller = "Courses", action = "getViewByCategory" },
                namespaces: new[] { "DDEDu.Controllers" }
            );

            //Định tuyến đến trang Khóa học của tôi
            routes.MapRoute(
            name: "toMyCourses",
            url: "my-courses",
            defaults: new { controller = "MyCourses", action = "Index" },
            namespaces: new[] { "DDEDu.Controllers" }
               );

            // Định nghĩa đường dẫn cho courses/{meta}/{id} để hiển thị chi tiết Course
            routes.MapRoute(
                name: "CourseDDetail",
                url: "courses/{metatitle}/{id}",
                defaults: new { controller = "Courses", action = "getDetail" },
                namespaces: new[] { "DDEDu.Controllers" }
            );

            // định nghĩa đường dẫn cho news/{meta} với meta là typepost
            // định tuyến đến trang index
            routes.MapRoute(
                name: "newdetail",
                url: "news/{meta}",
                defaults: new { controller = "news", action = "index" },
                namespaces: new[] { "DDEDu.controllers" }
            );


            // Định nghĩa đường dẫn cho news/{type}/{meta} để hiển thị chi tiết New
            //Với meta là typePost
            routes.MapRoute(
                name: "AccessNew",
                url: "news/{type}/{meta}",
                defaults: new { controller = "News", action = "getNewDetail" },
                namespaces: new[] { "DDEDu.Controllers" }
            );

            // Định nghĩa đường dẫn cho news/{meta}/{id} để hiển thị chi tiết New
            //Với meta là typePost
            //routes.MapRoute(
            //    name: "AccessNewMeta",
            //    url: "news/{meta}/{id}",
            //    defaults: new { controller = "News", action = "getNewDetail" },
            //    namespaces: new[] { "DDEDu.Controllers" }
            //);



            // Route mặc định
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "DDEDu.Controllers" }
            );
        }
    }
}