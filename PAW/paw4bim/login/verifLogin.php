<?php
    include "connect.php";
    session_start();

            $nome = $_POST['usuario'];
            $senha = $_POST['senha'];
            $login = false;

            $sql1 = "SELECT usuario,senha FROM usuario;";
            $resultado1 = mysqli_query($con,$sql1) or die(mysql_error()."<br>Erro ao executar a inserção dos dados");
            if (mysqli_num_rows($resultado1)!=0){
                while($elemento = mysqli_fetch_array($resultado1)){
                    $nomeItem1 = $elemento['usuario'];
                    $nomeItem2 = $elemento['senha'];
                    if($nome == $nomeItem1 and $senha == $nomeItem2){
                        $login = true;
                        $_SESSION['nome'] = $nome;
                        $_SESSION['senha'] = $senha;
                        ?>
                        <html>
                            <head>
                                <title>Menu</title>
                                <meta charset="utf-8">
                                <meta name="viewport" content="width=device-width, initial-scale=1">
                                <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet">
                                <link href="https://getbootstrap.com/docs/5.2/assets/css/docs.css" rel="stylesheet">
                            </head>
                            <style>
                                body{
                                    padding-left: 200px;
                                    padding-right: 200px;
                                    padding-top: 50px;
                                    padding-bottom: 50px;
                                }
                                .cards{
                                    padding-top: 20px;
                                }
                            </style>
                            <body>
                                <div class="card text-center">
                                    <h5 class="card-header">Criar nova sala de chat</h5>
                                    <div class="card-body">
                                    <h5 class="card-title">Clique no botao para criar uma nova sala de chat</h5>
                                    <a href="../novaSala/novaSala.html" class="btn btn-primary">Criar</a>
                                    </div>
                                </div>
                                <div class="cards">
                                    <div class="card text-center">
                                    <h5 class="card-header">Entrar em uma sala de chat</h5>
                                    <div class="card-body">
                                    <h5 class="card-title">Clique no botao para ver todas as salas</h5>
                                    <a href="../verSalas/verSalas.html" class="btn btn-primary">Ver</a>
                                    </div>
                                </div>
                                </div>

                            </body>
                        </html>
                        <?php
                    }
                }
            }
            if($login == false){
                ?><html>
                    <head>
                        <title>Erro</title>
                        <meta charset="utf-8">
                    </head>
                    <body>
                        <script src="LoginUsuario.js"></script>
                        <div id="conteudo">
                            Digite o usuario e senha: <br>
                            <input type="text" placeholder="usuario" name ="usuario" id="usuario"><br>
                            <input type="password" placeholder="senha" name ="senha" id="senha"><br>
                            <a href="../cadastro/CadastroUsuario.html">Cadastrar</a>
                            <input type="submit" value="login" onclick="login();">
                            Usuario ou senha invalidos!
                        </div>
                    </body>
                </html><?php
            }

?>