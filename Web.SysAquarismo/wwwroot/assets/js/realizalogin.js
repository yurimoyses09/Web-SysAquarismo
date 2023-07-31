function RealizaLogin(event, form) {
    const login_post = new Object();

    login_post.nome_login = document.getElementById("nome_usuario").value;
    login_post.senha = document.getElementById("senha").value;
    login_post.senha_repetida = document.getElementById("senha_repetida").value;

    fetch('http://localhost:5257/api/v1/peixe/login', {
        method: 'POST',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(login_post)})
        .then(data => {
            if (data.ok) {
                window.location.href('file:///C:/Users/yuhmo/OneDrive/%C3%81rea%20de%20Trabalho/PROJETOS/FrontSysAquarismo/page-inicial.html');
            }
        }).catch(e => { console.log(e) });
}