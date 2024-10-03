document.addEventListener('DOMContentLoaded', () => {
    const loginForm = document.getElementById('loginForm');

    loginForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        const email = document.getElementById('email').value;
        const senha = document.getElementById('senha').value;

        try {
            const response = await fetch('https://localhost:44366/api/Auth/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ email, senha })
            });

            const data = await response.json();

            if (data.value && data.value.token) {
                localStorage.setItem('token', data.value.token);
                localStorage.setItem('userId', data.value.id);
                localStorage.setItem('userName', data.value.nome);
                alert(data.value.mensagem || 'Login realizado com sucesso!');
                window.location.href = '/Home/CriarEvento'; // Redireciona para a página de criar evento
            } else {
                throw new Error(data.errors ? data.errors[0] : 'Login falhou');
            }
        } catch (error) {
            console.error('Erro no login:', error);
            alert('Falha no login. Verifique suas credenciais e tente novamente.');
        }
    });
});