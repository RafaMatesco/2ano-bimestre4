function verSalas(){
    const ajax = new XMLHttpRequest();
    ajax.onload = function(){
        document.getElementById('divResposta').innerHTML = this.responseText;
    }   
    ajax.open('POST','verSalas.php', true);
    ajax.setRequestHeader('Content-type', 'application/x-www-form-urlencoded'); 
    ajax.send();
}