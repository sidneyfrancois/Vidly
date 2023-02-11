using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Context;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private VidlyDataContext _context;

        public MovieController()
        {
            _context = new VidlyDataContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {

            var viewModel = new ListOfMoviesViewModel
            {
                Movies = _context.Movies.Include(m => m.Genre).ToList()
            };

            return View(viewModel);
        }

        public ActionResult Details(int id) 
        {
            var movie = _context.Movies.Include((c) => c.Genre).ToList().Find(item => item.Id == id);

            if (movie != null)
                return View(movie);
            else
                return HttpNotFound();
        }

        public ActionResult New()
        {
            return View();
        }
    }
}