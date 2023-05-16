function cadastroSalaBanco(){
    var sala = document.getElementById('sala').value;

    const ajax = new XMLHttpRequest();
    ajax.onload = function(){
        document.getElementById('divResposta').innerHTML = this.responseText;
    }   

    ajax.open('POST','InsertSala.php', true);
    ajax.setRequestHeader('Content-type', 'application/x-www-form-urlencoded'); 

    var variaveis = '';
    variaveis += '&sala=' + sala;
    ajax.send(variaveis);
}

function getNome(){
    const ajax = new XMLHttpRequest();
    ajax.onload = function(){
        document.getElementById('nome').innerHTML = this.responseText;
    }   
    ajax.open('POST','getNome.php', true);
    ajax.setRequestHeader('Content-type', 'application/x-www-form-urlencoded'); 
    ajax.send();
}