function login(){
    if(document.getElementById("usuario").value != "" && document.getElementById("senha").value != ""){
        var usuario = document.getElementById("usuario").value;
        var senha = document.getElementById("senha").value;
        var node = document.getElementById("conteudo");
        if (node.parentNode) {
            node.parentNode.removeChild(node);
        }

        const ajax = new XMLHttpRequest();
        ajax.onload = function(){
            document.getElementById('divResposta').innerHTML = this.responseText;
        }   

        ajax.open('POST','verifLogin.php', true);
        ajax.setRequestHeader('Content-type', 'application/x-www-form-urlencoded'); 

        var variaveis = '';
        variaveis += '&usuario=' + usuario;
        variaveis += '&senha=' + senha;
        ajax.send(variaveis);
    }

}