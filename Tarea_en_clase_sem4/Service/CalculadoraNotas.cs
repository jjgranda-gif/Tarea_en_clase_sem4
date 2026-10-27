// Services/CalculadoraNotas.cs
// Lógica de cálculo y validación (sin interfaz)

using System.Globalization;
using System.Text.RegularExpressions;

namespace Tarea_en_clase_sem4.Services;

// Estados posibles del estudiante
public enum EstadoEstudiante
{
    Aprobado,
    Complementario,
    Reprobado
}

// Resultado de validar un texto escrito por el usuario
// Valido: true si el dato es correcto | Valor: número convertido | Error: mensaje a mostrar
public record ResultadoValidacion(bool Valido, double Valor, string Error);

public static class CalculadoraNotas
{
    // Peso de cada componente según el enunciado
    public const double PesoSeguimiento = 0.3; // 30 %
    public const double PesoExamen = 0.2;      // 20 %

    // Redondea a 2 decimales para evitar errores como 6.999999
    public static double Redondear(double numero) =>
        Math.Round(numero, 2, MidpointRounding.AwayFromZero);

    // Valida que el texto sea un número entre 0 y 10
    // Controles: campo vacío, no numérico, fuera de rango
    public static ResultadoValidacion ValidarNota(string? texto)
    {
        // Aceptamos coma o punto decimal (ej: 8,5 u 8.5)
        var limpio = (texto ?? "").Trim().Replace(',', '.');

        // Control 1: campo vacío
        if (limpio == "")
            return new ResultadoValidacion(false, 0, "Este campo es obligatorio");

        // Control 2: solo datos numéricos (rechaza "abc", "8..5", "7a", "-3")
        if (!Regex.IsMatch(limpio, @"^[0-9]+(\.[0-9]+)?$"))
            return new ResultadoValidacion(false, 0, "Ingrese solo números positivos");

        // Convertimos usando punto decimal sin importar el idioma del equipo
        var numero = double.Parse(limpio, CultureInfo.InvariantCulture);

        // Control 3: rango permitido de 0 a 10
        if (numero < 0 || numero > 10)
            return new ResultadoValidacion(false, 0, "La nota debe estar entre 0 y 10");

        return new ResultadoValidacion(true, numero, "");
    }

    // Nota Parcial = (Seguimiento * 0.3) + (Examen * 0.2)  -> máximo 5 puntos
    public static double CalcularParcial(double seguimiento, double examen) =>
        Redondear(seguimiento * PesoSeguimiento + examen * PesoExamen);

    // Nota Final = Parcial 1 + Parcial 2  -> máximo 10 puntos
    public static double CalcularFinal(double parcial1, double parcial2) =>
        Redondear(parcial1 + parcial2);

    // Estado según la nota final:
    //  >= 7 Aprobado | >= 5 y < 7 Complementario | < 5 Reprobado
    public static EstadoEstudiante ObtenerEstado(double notaFinal)
    {
        if (notaFinal >= 7) return EstadoEstudiante.Aprobado;
        if (notaFinal >= 5) return EstadoEstudiante.Complementario;
        return EstadoEstudiante.Reprobado;
    }

    // Texto que se muestra al usuario (en mayúsculas como pide el enunciado)
    public static string TextoEstado(EstadoEstudiante estado) => estado switch
    {
        EstadoEstudiante.Aprobado => "APROBADO",
        EstadoEstudiante.Complementario => "COMPLEMENTARIO",
        _ => "REPROBADO"
    };
}