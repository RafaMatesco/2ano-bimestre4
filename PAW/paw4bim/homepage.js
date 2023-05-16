function getNome(){
    const ajax = new XMLHttpRequest();
    ajax.onload = function(){
        document.getElementById('nome').innerHTML = this.responseText;
    }   
    ajax.open('POST','getNome.php', true);
    ajax.setRequestHeader('Content-type', 'application/x-www-form-urlencoded'); 
    ajax.send();
}