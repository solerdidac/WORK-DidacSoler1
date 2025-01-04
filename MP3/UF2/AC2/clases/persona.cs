namespace AC2.Models
{
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public LinkedList<VideoJuego> Alquilados { get; set; }

        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
            Alquilados = new LinkedList<VideoJuego>();
        }

        public void AlquilarVideojuego(VideoJuego juego)
        {
            Alquilados.AddLast(juego);
        }

        public override string ToString()
        {
            return $"Persona: {Nombre}, Edad: {Edad}";
        }
    }
}
