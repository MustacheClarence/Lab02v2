using Microsoft.AspNetCore.Mvc;
using Lab02.Models;

namespace Lab02.Controllers
{
    // Falta Agregar manualmente

    [Route("[controller]")]
    public class TeamController : Controller
    {
        CustomTimer tiempo = new CustomTimer();

        List<Team> teamsList = new List<Team>();


        [Route("BuscarEquipo")]
        public IActionResult BuscarEquipoName() { return View(); }
        public IActionResult BuscarEquipoCoach() { return View(); }
        public IActionResult BuscarEquipoLiga() { return View(); }
        public IActionResult BuscarEquipoCD() { return View(); }

        [HttpPost("BuscarEquipo")]
        public IActionResult BuscarEquipoName(string name) 
        {
            Team team = new Team();
            for(int i = 0; i < teamsList.Count; i++)
            {
                if (teamsList[i].TeamName == name)
                {
                    team = teamsList[i];
                }
            }
            return View(team); 
        }
        public IActionResult BuscarEquipoCoach(string coach) 
        {
            Team team = new Team();
            for (int i = 0; i < teamsList.Count; i++)
            {
                if (teamsList[i].TeamCoach == coach)
                {
                    team = teamsList[i];
                }
            }
            return View(team); 
        }
        public IActionResult BuscarEquipoLiga(string league) 
        {
            Team team = new Team();
            for (int i = 0; i < teamsList.Count; i++)
            {
                if (teamsList[i].League == league)
                {
                    team = teamsList[i];
                }
            }
            return View(team); 
        }
        public IActionResult BuscarEquipoCD(string creationdate) 
        {
            Team team = new Team();
            for (int i = 0; i < teamsList.Count; i++)
            {
                if (teamsList[i].CreationDate == creationdate)
                {
                    team = teamsList[i];
                }
            }
            return View(team); 
        }




        [Route("AgregarEquipo")]
        public IActionResult AgregarEquipo()
        {
            return View();
        }
        [HttpPost("AgregarEquipo")]
        public IActionResult AgregarEquipo(string Name, string coach, string league, string creationDate)
        {
            tiempo.Start();
            Team nuevoTeam = new Team();
            nuevoTeam.TeamName = Name;
            nuevoTeam.TeamCoach = coach;
            nuevoTeam.League = league;
            nuevoTeam.CreationDate = creationDate;
            teamsList.Add(nuevoTeam);
            tiempo.Stop();
            return View(nuevoTeam);
        }



        [Route("SubirArchivo")]
        public IActionResult SubirArchivo()
        {
            return View();
        }


        [HttpPost("SubirArchivo")]
        public IActionResult SubirArchivo(IFormFile file)
        {
            tiempo.Start();
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
            tiempo.Stop();
            return View(teamsList);
        }
    }
}
