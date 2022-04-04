using Microsoft.AspNetCore.Mvc;
using Lab02.Models;

namespace Lab02.Controllers
{
        
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        CustomTimer tiempo = new CustomTimer();

        List<Player> playersList = new List<Player>();



        [Route("BuscarJugador")]
        public IActionResult BuscarJugadorName()
        {
            return View();
        }
        public IActionResult BuscarJugadorRol()
        {
            return View();
        }
        public IActionResult BuscarJugadorKDA()
        {
            return View();
        }
        public IActionResult BuscarJugadorCS()
        {
            return View();
        }
        public IActionResult BuscarJugadorTeam()
        {
            return View();
        }

        [HttpPost("BuscarJugador")]
        public IActionResult BuscarJugadorName(string name, string Lname)
        {
            tiempo.Start();
            Player player = new Player();
            for (int i = 0; i < playersList.Count; i++)
            {
                if (playersList[i].Name == name && playersList[i].LName == Lname)
                {
                   player = playersList[i];
                    break;
                }
            }
            tiempo.Stop();
            return View(player);
        }
        public IActionResult BuscarJugadorRol(string rol)
        {
            tiempo.Start();
            List<Player> RolList = new List<Player>();
            for (int i = 0;i < playersList.Count; i++)
            {
                if (playersList[i].Rol == rol)
                {
                    RolList.Add(playersList[i]);
                }
            }
            tiempo.Stop();
            return View(RolList);
        }
        public IActionResult BuscarJugadorKDA(double kda)
        {
            tiempo.Start();
            List<Player> KDAList = new List<Player>();
            for (int i = 0; i < playersList.Count; i++)
            {
                if (playersList[i].KDA == kda)
                {
                    KDAList.Add(playersList[i]);
                }
            }
            tiempo.Stop();
            return View();
        }
        public IActionResult BuscarJugadorCS(int cs)
        {
            tiempo.Start();
            List<Player> CSList = new List<Player>();
            for (int i = 0; i < playersList.Count; i++)
            {
                if (playersList[i].CS == cs)
                {
                    CSList.Add(playersList[i]);
                }
            }
            tiempo.Stop();
            return View();
        }
        public IActionResult BuscarJugadorTeam(string team)
        {
            tiempo.Start();
            List<Player> TeamList = new List<Player>();
            for (int i = 0; i < playersList.Count; i++)
            {
                if (playersList[i].Team == team)
                {
                    TeamList.Add(playersList[i]);
                }
            }
            tiempo.Stop();
            return View();
        }




        [Route("AgregarJugador")]
        public IActionResult AgregarJugador() 
        { 
            return View(); 
        }

        [HttpPost("AgregarJugador")]
        public IActionResult AgregarJugador(string name, string LName, string Team, string Rol, double KDA, int CS)
        {
            tiempo.Start();
            Player nuevoPlayer = new Player();
            nuevoPlayer.Name = name;
            nuevoPlayer.LName = LName;
            nuevoPlayer.Team = Team;
            nuevoPlayer.Rol = Rol;
            nuevoPlayer.KDA = KDA;
            nuevoPlayer.CS = CS;
            playersList.Add(nuevoPlayer);
            tiempo.Stop();
            return View(playersList);
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
                            var player = new Player();
                            player.Name = informacion[0];
                            player.LName = informacion[1];
                            player.Team = informacion[2];
                            player.Rol = informacion[3];
                            player.KDA = Convert.ToDouble(informacion[4]);
                            player.CS = Convert.ToInt32(informacion[5]);
                            playersList.Add(player);
                        }
                    }
                }
                catch (Exception e)
                {

                    ViewBag.Error = e.Message;
                }
            }
            tiempo.Stop();
            return View(playersList);
        }
    }
}
