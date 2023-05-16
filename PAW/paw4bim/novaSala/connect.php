<?php
    $host = "127.0.0.1";
    $usuario = "root";
    $senha = "";
    $banco ="chatpaw";
    $porta = "3306";
    $con = new mysqli($host, $usuario, $senha,$banco,$porta);
    if ($con->connect_error) {
        die("Falha ao conectar: " . $con->connect_error);
    }
?>