namespace AC2.Models
{
    public class VideoJuego
    {
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Tematica { get; set; }
        public bool Alquilado { get; set; }
        public Persona? UsuarioAlquilado { get; set; }

        public VideoJuego(string titulo, int anio, string tematica)
        {
            Titulo = titulo;
            Anio = anio;
            Tematica = tematica;
            Alquilado = false;
            UsuarioAlquilado = null;
        }

        public override string ToString()
        {
            string estado = Alquilado ? $"Alquilado por {UsuarioAlquilado?.Nombre}" : "Disponible";
            return $"Titulo: {Titulo}, Año: {Anio}, Temática: {Tematica}, Estado: {estado}";
        }
    }
}
