﻿namespace AgendaPro.Application.Models.Responses.Tarefas
{
    public class CreateTarefaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool TarefaCompleta { get; set; }
    }
}