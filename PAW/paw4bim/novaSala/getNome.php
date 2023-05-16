<?php
    session_start();

    echo ' voce esta logado como: '.$_SESSION['nome'].' <a class="btn btn-warning" href="login/LoginUsuario.html">Sair</a> <br><br>';
?>