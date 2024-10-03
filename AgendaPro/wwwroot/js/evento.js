document.addEventListener('DOMContentLoaded', () => {
    if (!verificarAutenticacao()) {
        alert('Você precisa fazer login para acessar esta página.');
        window.location.href = '/Home/Login';
        return;
    }

    const form = document.getElementById('eventoForm');
    const submitButton = form.querySelector('button[type="submit"]');
    let isSubmitting = false;

    form.addEventListener('submit', async (e) => {
        e.preventDefault();

        if (isSubmitting) {
            console.log('Submissão já em andamento. Ignorando este evento.');
            return;
        }

        isSubmitting = true;
        submitButton.disabled = true;

        const token = localStorage.getItem('token');
        const userId = localStorage.getItem('userId');

        const evento = {
            usuarioId: userId,
            titulo: document.getElementById('titulo').value,
            descricao: document.getElementById('descricao').value,
            dataInicio: document.getElementById('dataInicio').value,
            dataFim: document.getElementById('dataFim').value,
            local: document.getElementById('local').value,
            tarefas: Array.from(document.querySelectorAll('.tarefa')).map(tarefa => ({
                nome: tarefa.querySelector('input[type="text"]').value,
                tarefaCompleta: tarefa.querySelector('input[type="checkbox"]').checked
            })),
            lembretes: Array.from(document.querySelectorAll('.lembrete')).map(lembrete => ({
                descricao: lembrete.querySelector('input[type="text"]').value,
                horaLembrete: lembrete.querySelector('input[type="datetime-local"]').value
            })),
            requestId: Date.now() // Adiciona um ID único para a requisição
        };

        try {
            const response = await fetch('https://localhost:44366/api/Eventos/create', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify(evento)
            });

            const data = await response.json();

            if (data.hasSuccess) {
                alert('Evento criado com sucesso!');
                form.reset();
            } else {
                alert(`Erro ao criar evento: ${data.message}`);
            }
        } catch (error) {
            console.error('Erro ao enviar requisição:', error);
            alert('Ocorreu um erro ao criar o evento. Por favor, tente novamente.');
        } finally {
            isSubmitting = false;
            submitButton.disabled = false;
        }
    });
});

function verificarAutenticacao() {
    const token = localStorage.getItem('token');
    return !!token;
}