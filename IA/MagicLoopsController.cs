using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class MagicLoopsController : Controller
{
    private readonly HttpClient _httpClient;

    public MagicLoopsController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost]
    public async Task<IActionResult> EjecutarLoop(string pregunta)
    {
        if (string.IsNullOrWhiteSpace(pregunta))
        {
            return Content("Por favor, ingresa una pregunta.");
        }

        var json = $"{{ \"question\": \"{pregunta}\" }}";
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync("https://magicloops.dev/api/loop/17115a1d-42b3-43ee-9926-ad022504ded6/run", content);
            var resultado = await response.Content.ReadAsStringAsync();

            return View("Resultado", resultado);
        }
        catch (Exception ex)
        {
            return Content("Error al llamar a la API: " + ex.Message);
        }
    }
}





