using System.Web.Mvc;
using System.Web.Routing;

namespace DDEdu
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

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