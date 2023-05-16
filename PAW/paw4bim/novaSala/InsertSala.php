<?php
    include 'connect.php';
    session_start();

    $sala = $_POST['sala'];
    $nome = $_SESSION['nome'];

    $query = $con->prepare("insert into sala (nomeSala,criadorSala) values (?,?)");
    $query->bind_param("ss", $sala,$nome);
    $query->execute();

    echo 'sala criada com sucesso!  <a href="../homepage.html">Voltar</a>';
?>

