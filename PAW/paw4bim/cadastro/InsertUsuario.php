<?php
    include 'connect.php';
    session_start();

    $nome = $_POST['usuario'];
    $senha = $_POST['senha'];
    
    if(!empty($nome) and !empty($senha)){
        $query = $con->prepare("insert into usuario (usuario,senha) values (?,?)");
        $query->bind_param("ss", $nome,$senha);
        $query->execute();
        echo 'Cadastrado com sucesso.';
    }else{
        echo 'Erro ao cadastrar, tente novamente.';
    }
    
?>

