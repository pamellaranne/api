using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using projeto360.Dominio.Entidades;
using projeto360.Servicos.Interfaces;
using projeto360.Servicos.JsonPlaceHolder.Models;

public class JsonPlaceHolderServico :IJsonPlaceHolderServico
{
    private readonly HttpClient _httpClient;

    public JsonPlaceHolderServico()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
    }

    public async Task<List<Tarefa>> ListarTarefas()
    {
        HttpResponseMessage reponse = await _httpClient.GetAsync("todos");
        reponse.EnsureSuccessStatusCode();

        string responseBody = await reponse.Content.ReadAsStringAsync();
        var todos = JsonConvert.DeserializeObject<List<Todo>>(responseBody);

        var tarefas = todos.Select(todo => new Tarefa
        {
            Id = todo.Id,
            Nome = todo.Title,
            Completa = todo.Completed
        }).ToList();

        return tarefas;
    }
}