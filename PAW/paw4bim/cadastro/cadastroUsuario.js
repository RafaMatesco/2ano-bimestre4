function CadastroUsuarioBanco(){
    var usuario = document.getElementById('usuario').value;
    var senha = document.getElementById('senha').value;

    const ajax = new XMLHttpRequest();
    ajax.onload = function(){
        document.getElementById('divResposta').innerHTML = this.responseText;
    }   
    
    ajax.open('POST','InsertUsuario.php', true);
    ajax.setRequestHeader('Content-type', 'application/x-www-form-urlencoded'); 

    var variaveis = '';
    variaveis += '&usuario=' + usuario;
    variaveis += '&senha=' + senha;
    ajax.send(variaveis);
}