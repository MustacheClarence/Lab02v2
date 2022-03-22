using Microsoft.AspNetCore.Mvc;
using Lab02.Models;

namespace Lab02.Controllers
{
    // Falta Agregar manualmente

    [Route("[controller]")]
    public class TeamController : Controller
    {
        List<Team> teamsList = new List<Team>();

        [Route("SubirArchivo")]
        public IActionResult SubirArchivo()
        {
            return View();
        }


        [HttpPost("SubirArchivo")]
        public IActionResult SubirArchivo(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    string ruta = Path.Combine(Path.GetTempPath(), file.Name);
                    using (var stream = new FileStream(ruta, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    string allFileData = System.IO.File.ReadAllText(ruta);
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            string[] informacion = lineaActual.Split(',');
                            var team = new Team();
                            team.TeamName = informacion[0];
                            team.TeamCoach = informacion[1];
                            team.League = informacion[2];
                            team.CreationDate = informacion[3];
                            teamsList.Add(team);
                        }
                    }
                }
                catch (Exception e)
                {

                    ViewBag.Error = e.Message;
                }
            }
            return View(teamsList);
        }
    }
}
